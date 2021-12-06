using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CombatTrigger : MonoBehaviour
{
    [SerializeField]
    List<EnemySpawner> enemies;
    float _elapsedTime;
    CombatController _combatController;
    [SerializeField]
    CinemachineVirtualCamera _combatCamera;
    [SerializeField]
    int _requiredKills;
    int _kills;
    float _combatTime;
    bool _canSpawn;
    List<EnemySpawner> _enemiesToinstantiate;
    GameObject _boundaries;
    [SerializeField] EnemyHPPool _enemyHPPool;
    bool _done;
    private string previousSong;
    void Start()
    {
        _combatController = FindObjectOfType<CombatController>();
        
    }
    public int GetKills()
    {
        return _kills;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_done)
        {
            _done = true;
            if (other.CompareTag("Player"))
            {
                _combatController.StartCombat(this);
                previousSong = FindObjectOfType<OSTController>()?.GetComponent<AudioSource>().clip.name;
                FindObjectOfType<OSTController>()?.ChangeSong("am_ab_al_combat_v1_mp3");
                StartCoroutine(AddBoundaries());
            }    
        }
        
    }

    public IEnumerator AddBoundaries()
    {
        yield return new WaitForSeconds(2f);
        BoxCollider myBC = GetComponent<BoxCollider>();
         _boundaries= new GameObject();
        _boundaries.transform.position = transform.position;
        BoxCollider _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3(0, 0, (myBC.size.z/2f)+1);
        _bc.size = new Vector3(myBC.size.x,myBC.size.y,2);
        _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3(0, 0,(- myBC.size.z / 2f)+1);
        _bc.size = new Vector3(myBC.size.x, myBC.size.y, 2);
        _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3((myBC.size.x / 2f)+1, 0, 0);
        _bc.size = new Vector3(2, myBC.size.y, myBC.size.z);
        _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3((-myBC.size.x / 2f)+1, 0, 0);
        _bc.size = new Vector3(2, myBC.size.y, myBC.size.z);
    }

    public void RemoveBoundaries()
    {
        Destroy(_boundaries);
        FindObjectOfType<OSTController>().ChangeSong(previousSong);
        //Destroy(gameObject);
    }

    public void AddKill()
    {
        _kills++;
        if (_kills >= _requiredKills)
        {
            _combatController.EndCombat();
            RemoveBoundaries();
        }
    }
    public CinemachineVirtualCamera GetCombatCamera()
    {
        return _combatCamera;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.9f, 0.1f, 0.0f, 0.5f);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, GetComponent<BoxCollider>().size);
        Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);
    }

    public void SpawnEnemies()
    {
        _canSpawn = true;
        _enemiesToinstantiate = new List<EnemySpawner>();
        foreach (EnemySpawner en in enemies)
        {
            _enemiesToinstantiate.Add(en);
        }
    }

    void Update()
    {
        if (_canSpawn)
        {
            List<EnemySpawner> enemiesToRemove = new List<EnemySpawner>();
            for(int i = 0; i<_enemiesToinstantiate.Count; i++)
            {
                if (_kills >= _enemiesToinstantiate[i]._previousKills)
                {
                    enemiesToRemove.Add(_enemiesToinstantiate[i]);
                    StartCoroutine(SpawnOneEnemy(_enemiesToinstantiate[i]));
                }
            }
            for(int i = 0; i< enemiesToRemove.Count; i++)
            {
                _enemiesToinstantiate.Remove(enemiesToRemove[i]);
            }
        }
    }

    IEnumerator SpawnOneEnemy(EnemySpawner en)
    {
        yield return new WaitForSeconds(en._time);
        EnemyController enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/" + en.GetEnemyType().ToString()), en.transform.position, en.transform.rotation).GetComponent<EnemyController>();
        enemy.SetCombatTrigger(this);
        _enemyHPPool.AddBar(enemy);

    }
}
