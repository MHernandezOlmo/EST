using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CombatTrigger : MonoBehaviour
{
    [SerializeField] GameObject _customCollider, _combatActivator;
    [SerializeField] string _combatName;
    [SerializeField] List<EnemySpawner> enemies;
    [SerializeField] CinemachineVirtualCamera _combatCamera;
    [SerializeField] private int _requiredKills, _kills, _previousMode, _startingPoint;
    [SerializeField] EnemyHPPool _enemyHPPool;
    [SerializeField] private bool _startingDash, _basement;
    CombatController _combatController;
    private bool _canSpawn, _done;
    List<EnemySpawner> _enemiesToinstantiate;
    GameObject _boundaries;

    void Start()
    {
        if(_combatName != "")
        {
            if (PlayerPrefs.GetInt(_combatName, 0) == 1)
            {
                _done = true;
                gameObject.SetActive(false);
            }
        }
        _combatController = FindObjectOfType<CombatController>();
        if (_startingDash)
        {
            CurrentSceneManager.CanDash = true;
        }
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
                _previousMode = MusicManager.currentClipIndex;
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.Combat);
                if(_customCollider == null)
                {
                    AddBoundaries();
                }
                else
                {
                    _customCollider.SetActive(true);
                }
                GameProgressController.SetCurrentStartPoint(_startingPoint);
            }
        }
    }

    public void AddBoundaries()
    {
        BoxCollider myBC = GetComponent<BoxCollider>();
         _boundaries= new GameObject();
        _boundaries.transform.position = transform.position;
        BoxCollider _bc = _boundaries.AddComponent<BoxCollider>();
        float offset = 1f;
        float zPosOffset = 3f;
        _bc.center = new Vector3(0, 0, (myBC.size.z/2f)+ offset + zPosOffset);
        _bc.size = new Vector3(myBC.size.x + (offset * 2f), myBC.size.y,2);
        _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3(0, 0,(- myBC.size.z / 2f) - offset + myBC.center.z -2);
        _bc.size = new Vector3(myBC.size.x + (offset * 2f), myBC.size.y, 2);
        _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3((myBC.size.x / 2f), 0, 0);
        _bc.size = new Vector3(2, myBC.size.y, myBC.size.z + (offset * 7f));
        _bc = _boundaries.AddComponent<BoxCollider>();
        _bc.center = new Vector3((-myBC.size.x / 2f), 0, 0);
        _bc.size = new Vector3(2, myBC.size.y, myBC.size.z + (offset * 7f));
    }

    public void RemoveBoundaries()
    {
        Destroy(_boundaries);
        RestoreMusic();
        //Destroy(gameObject);
    }

    public void RestoreMusic()
    {
        if (_previousMode == -1)
        {
            AudioEvents.playMusicTransitionWithMusicCode.Invoke((MusicManager.MusicCode)FindObjectOfType<MusicManager>().GetRandomMusicIndex());
        }
        else
        {
            AudioEvents.playMusicTransitionWithMusicCode.Invoke((MusicManager.MusicCode)_previousMode);
        }
    }

    public void AddKill()
    {
        _kills++;
        if (_kills >= _requiredKills)
        {
            PlayerPrefs.SetInt(_combatName, 1);
            _combatController.EndCombat();
            if (_basement)
            {
                FindObjectOfType<MusicManager>().PlayMusicTransition(FindObjectOfType<MusicManager>().GetLastRandomMusicIndex());
            }
            if(_combatActivator != null)
            {
                StartCoroutine(CrWaitForReloadCombatMode());
            }
            if(_customCollider == null)
            {
                RemoveBoundaries();
            }
            else
            {
                FindObjectOfType<MusicManager>().PlayMusicTransition(FindObjectOfType<MusicManager>().GetLastRandomMusicIndex());
                _customCollider.SetActive(false);
            }
        }
    }

    IEnumerator CrWaitForReloadCombatMode()
    {
        _combatActivator.SetActive(false);
        yield return null;
        _combatActivator.SetActive(true);
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

    public bool IsDone()
    {
        return _done;
    }
}
