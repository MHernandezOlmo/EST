using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject _spin;
    GameObject _startingPositions;
    [SerializeField] GameObject _realGoran;
    [SerializeField] GameObject _shield;
    private CameraShake _cameraShake;
    private VignettingController _vignettingController;
    public enum Character {Goran, MsProminence, Flare, Eclipse, None};
    public Character _currentCharacter;
    [SerializeField] GameObject _solarCanonBall;
    float _shootTime;
    float _elapsedShootTime;
    bool isShielding;
    [SerializeField] AnimationCurve _animationCurve;
    private Animator _animator;
    private bool _superRotate;
    private int _currentHp;
    private int _maxHP =300;
    private bool _dead;
    public HPBar _currentHPBar;
    float _restoreHP = 0f;
    public int GetMaxHP()
    {
        return _maxHP;
    }
    
    public int GetHP()
    {
        return _currentHp;
    }

    public void ReceiveDamage(int newValue)
    {
        if (FindObjectOfType<CameraShake>() == null)
        {
            Camera.main.gameObject.AddComponent<CameraShake>();
            _cameraShake = FindObjectOfType<CameraShake>();
        }
        else
        {
            _cameraShake = FindObjectOfType<CameraShake>();
        }
        if (!_dead)
        {
            _currentHPBar.Show();
            _currentHp -= newValue;
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.Hit);
            _cameraShake.ShakeCamera(0.08f, 0.1f);
            _vignettingController.ReceiveHit();
            if (_currentHp <=0)
            {
                _currentHp = 0;
                _dead = true;
                _animator.SetTrigger("Die");
                StartCoroutine(CrWaitForDie());
            }   
        }
    }

    public event EventHandler HpChange;
    [SerializeField]
    private GameObject _shootPosition;
    [SerializeField] private ParticleSystem electricBall1;
    void Start()
    {
        _currentHp = _maxHP;
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _shootTime = 1f;
        _vignettingController = FindObjectOfType<VignettingController>();
        Physics.gravity = Vector3.zero; 
        GameProgressController.SetCurrentScene(SceneManager.GetActiveScene().name);
        StartCoroutine(CrPosition());
    }

    IEnumerator CrWaitForDie()
    {
        yield return new WaitForSeconds(1f);
        AudioEvents.playDefMusic.Invoke();
        GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
    }

    IEnumerator CrPosition()
    {
        yield return null;
        _startingPositions = GameObject.Find("StartingPositions");
        //El jugador aparecerá en la escena siempre en base al parámetro "StartPoint" del GameProgressController. Si dicho parámetro no está definido o es menor que 0, por defecto cogerá el elemento 0.
        //Paso 0, obtengo el parámetro "PreviousPoint"
        int startingPoint = GameProgressController.GetStartPoint();
        //Paso 1, si es menor que 0, lo dejo en 0
        startingPoint = Mathf.Max(0, startingPoint);
        //Paso 2, obtengo la posición final. Para ello, utilizo la posición del hijo nº {{startingPoint}} del objeto {{_startingPositions}}
        if(startingPoint > _startingPositions.transform.childCount-1)
        {
            startingPoint = 0;
        }
        Vector3 targetPosition = _startingPositions.transform.GetChild(startingPoint).position;
        //Paso 3, coloco al jugador en la posición obtenida.
        transform.position = targetPosition;
        Physics.gravity = new Vector3(0,-9.8f,0);
        //Paso 4, oriento al jugador según el forward del objeto
        transform.LookAt(targetPosition+ _startingPositions.transform.GetChild(startingPoint).forward);        
    }
    

    void Update()
    {
        _restoreHP += Time.deltaTime*10;
        if (_restoreHP >= 1)
        {
            _currentHp++;
            _restoreHP = 0;
        }
        if (_currentHp > _maxHP)
        {
            _currentHp = _maxHP;
        }
        if (_currentCharacter == Character.Goran)
        {
            if (_superRotate)
            {
                _realGoran.transform.Rotate(new Vector3(0,3600*Time.deltaTime,0));
            }
            else
            {
                _realGoran.transform.localRotation = Quaternion.Euler(0,-21.1f,0);
            }
        }
        if (_currentCharacter == Character.Flare)
        {
            _elapsedShootTime += Time.deltaTime;
            
        }
        if (PlayerInput._ContextButtonDown)
        {
            print("QEWR");
            if (CurrentSceneManager._state == GameStates.Combat )
            {
                if (_currentCharacter == Character.Eclipse)
                {
                    if (CurrentSceneManager._canShield)
                    {
                        CurrentSceneManager._canShield = false;
                        if (!isShielding)
                        {
                            StartCoroutine(CrUseShield());
                        }    
                    }
                }
                if (_currentCharacter == Character.MsProminence)
                {
                    if (CurrentSceneManager.CanDash)
                    {
                        CurrentSceneManager.CanDash = false;
                        StartCoroutine(CrDash());    
                    }
                }
                if (_currentCharacter == Character.Flare)
                {
                    if(_elapsedShootTime > _shootTime)
                    {
                        _elapsedShootTime = 0;
                        StartCoroutine(CrShoot());
                    }
                }
                if (_currentCharacter == Character.Goran)
                {
                    if (CurrentSceneManager._canSpin)
                    {
                        CurrentSceneManager._canSpin = false;
                        StartCoroutine(CrSpin());  
                    }
                }
                if (_currentCharacter == Character.MsProminence)
                {
                    StartCoroutine(CrDash());    
                }
            }
            else
            {
                if (_currentCharacter == Character.Flare)
                {
                    
                    if (CurrentSceneManager._skillEnabled)
                    {
                        if (_currentCharacter == Character.Flare)
                        {
                            if(_elapsedShootTime > _shootTime)
                            {
                                _elapsedShootTime = 0;
                                StartCoroutine(CrShoot());
                            }
                        }
                    }
                }
                if (_currentCharacter == Character.MsProminence)
                {
                    if (CurrentSceneManager.CanDash)
                    {
                        CurrentSceneManager.CanDash = false;
                        StartCoroutine(CrDash());
                    }
                }
                if (CurrentSceneManager._state == GameStates.Exploration)
                {
                    FindObjectOfType<InteractablesController>().Interact();
                }
            }
        }
    }
    IEnumerator CrShoot()
    {
        AudioEvents.playSoundWithNameAndPitch.Invoke(SFXManager.AudioCode.LaserShoot, 0.8f);
        GetComponent<MovementController>().enabled = false;
        _animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.4f);
        electricBall1.transform.position = _shootPosition.transform.position;
        electricBall1.Play();
        Vector3 myShootPosition = _shootPosition.transform.position;
        myShootPosition.y = transform.position.y;
        GameObject ball = Instantiate(_solarCanonBall, _shootPosition.transform.position, Quaternion.identity);

        EnemyController[] _enemies = FindObjectsOfType<EnemyController>();

        List<float> angles = new List<float>();
        for(int i  =0;i< _enemies.Length; i++)
        {
            Vector3 neutralYEnemyPosition = _enemies[i].transform.position;
            neutralYEnemyPosition.y = ball.transform.position.y;
            float ang = Vector3.Angle(transform.forward, neutralYEnemyPosition - transform.position);
            
            angles.Add(ang);
        }

        int enemyIndex = -1;
        float minAngle = 1000;
        for (int i = 0; i < angles.Count; i++)
        {
            if (angles[i] < 45)
            {
                if (angles[i] < minAngle)
                {
                    enemyIndex = i;
                    minAngle = angles[i];
                }
            }
        }

        if (enemyIndex >= 0)
        {
            Vector3 neutralYEnemyPosition = _enemies[enemyIndex].transform.position;
            neutralYEnemyPosition.y = ball.transform.position.y;
            ball.transform.LookAt(_shootPosition.transform.position + (neutralYEnemyPosition - _shootPosition.transform.position).normalized* 2);
        }
        else
        {
            ball.transform.LookAt(_shootPosition.transform.position + transform.forward * 2);
        }
        yield return new WaitForSeconds(0.45f);
        GetComponent<MovementController>().enabled = true;
    }
    IEnumerator CrUseShield()
    {
        
        _animator.SetTrigger("Attack");
        GetComponent<MovementController>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        _shield.SetActive(true);

        electricBall1.Play();
        for(float i = 0; i<0.2f; i += Time.deltaTime)
        {
            _shield.transform.localScale = Vector3.one * _animationCurve.Evaluate((i / 0.2f)); ;
            yield return null;
        }
        _shield.transform.localScale = Vector3.one;
        isShielding = true;
        yield return new WaitForSeconds(0.2f);
        for (float i = 0; i < 0.5f; i += Time.deltaTime)
        {
            _shield.transform.localScale = Vector3.one- Vector3.one * _animationCurve.Evaluate((i / 0.5f));
            yield return null;
        }
        _shield.transform.localScale = Vector3.zero;

        _shield.SetActive(false);
        _shield.transform.localScale = Vector3.one;
        isShielding = false;
        GetComponent<MovementController>().enabled = true;
        yield return new WaitForSeconds(1);
        CurrentSceneManager._canShield = true;
    }
    IEnumerator CrDash()
    {

        EnemyController[] _enemies = FindObjectsOfType<EnemyController>();

        List<float> angles = new List<float>();
        for (int i = 0; i < _enemies.Length; i++)
        {
            float ang = Vector3.Angle(transform.forward, _enemies[i].transform.position - transform.position);

            angles.Add(ang);
        }

        int enemyIndex = -1;
        float minAngle = 1000;
        for (int i = 0; i < angles.Count; i++)
        {
            if (angles[i] < 45)
            {
                if (angles[i] < minAngle)
                {
                    enemyIndex = i;
                    minAngle = angles[i];
                }
            }
        }
        if (enemyIndex >= 0)
        {
            transform.LookAt(_enemies[enemyIndex].transform.position);
        }
        GetComponent<MovementController>().enabled = false;
        _animator.SetTrigger("Attack");
        Vector3 startingPosition = transform.position;
        Vector3 targetPosition = transform.position + transform.forward * 5f;
        //_spin.SetActive(true);
        electricBall1.Play();
        yield return new WaitForSeconds(0.2f);
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            _realGoran.transform.localPosition= Vector3.Lerp(Vector3.zero, Vector3.up, i/0.1f); 
            _realGoran.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero,i/0.1f);

            //transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero,i/0.3f);
            yield return null;
        }

        _realGoran.transform.localPosition = Vector3.up; 

        
        Vector3 currentPosition = transform.position;
        Vector3 raycastStart = currentPosition+Vector3.up*0.5f;
        Vector3 raycastStartLeft = currentPosition+Vector3.up*0.5f +transform.right * -0.5f;
        Vector3 raycastStartRight = currentPosition+Vector3.up*0.5f + transform.right*0.5f;
        Vector3 raycastEnd = targetPosition;
        Vector3 raycastEndLeft = targetPosition + transform.right * -0.5f;
        Vector3 raycastEndRight = targetPosition + transform.right * 0.5f;
        var hits = Physics.RaycastAll(raycastStart, transform.forward, 5);
        foreach (var hit in hits)
        {
            if (!(hit.collider.gameObject.GetComponent<EnemyController>() != null))
            {
                targetPosition = hit.point;
            }
        }
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(currentPosition, targetPosition, i / 0.1f);
            yield return null;
        }
        transform.position = targetPosition;
        RaycastHit hitInfo;
        hits = Physics.RaycastAll(raycastStart, transform.forward, 5);
        var hits2 = Physics.RaycastAll(raycastStartLeft, transform.forward, 5);
        var hits3 = Physics.RaycastAll(raycastStartRight, transform.forward, 5);
        List<GameObject> hitEnemies = new List<GameObject>(); ;
        foreach(var hit in hits)
        {
            if(hit.collider.gameObject.GetComponent<EnemyController>()!=null)
            {
                if (!hitEnemies.Contains(hit.collider.gameObject))
                {
                    hitEnemies.Add(hit.collider.gameObject);
                }
            }
        }
        foreach(GameObject g in hitEnemies)
        {
            g.GetComponent<EnemyController>().ReceiveDamage(50);
        }
        for(float i = 0; i< 0.1f; i += Time.deltaTime)
        {
            _realGoran.transform.localScale = Vector3.Lerp( Vector3.zero,Vector3.one, i/0.1f);
            yield return null;
            _realGoran.transform.localPosition= Vector3.Lerp( Vector3.up*2,Vector3.zero, i/0.1f); 

            //transform.position = Vector3.Lerp(startingPosition, targetPosition, i/0.25f);
        }
        _realGoran.transform.localPosition= Vector3.zero;
        _realGoran.transform.localScale = Vector3.one;
        GetComponent<MovementController>().enabled = true;
        //_spin.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        CurrentSceneManager.CanDash = true;
    }
    IEnumerator CrSpin()
    {
        _animator.SetTrigger("Attack");
        _spin.SetActive(true);
        _superRotate = true;
        AudioEvents.playSoundWithNameAndPitch.Invoke(SFXManager.AudioCode.Tornado, 1.5f);
        for(float i =0; i< 1f; i += Time.deltaTime)
        {
            yield return null;
            Collider[] nearEnemyColliders = Physics.OverlapSphere(transform.position, 1.5f, 1 << 8);
            foreach (Collider g in nearEnemyColliders)
            {
                if (g.transform.root.GetComponent<EnemyController>() != null)
                {
                    g.transform.root.GetComponent<EnemyController>().ReceiveDamage(Mathf.CeilToInt(100*Time.deltaTime));
                }
                else
                {
                    if(g.transform.root.GetComponent<LamparaBot>() != null)
                    {
                        g.transform.root.GetComponent<LamparaBot>().Die();
                    }
                }
            }
        }
        _spin.SetActive(false);
        _superRotate = false;

        yield return new WaitForSeconds(0.25f); //Attack wait time
        CurrentSceneManager._canSpin = true;
    }
}
