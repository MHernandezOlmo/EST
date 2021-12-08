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
    private int _maxHP =160;
    private bool _dead;
    public HPBar _currentHPBar;

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
        if (!_dead)
        {
            _currentHPBar.Show();
            _currentHp -= newValue;
            if (_currentHp <=0)
            {
                _currentHp = 0;
                _dead = true;
                _animator.SetTrigger("Die");
                GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
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
        
        Physics.gravity = Vector3.zero; 
        GameProgressController.SetCurrentScene(SceneManager.GetActiveScene().name);
        StartCoroutine(CrPosition());
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
                if(CurrentSceneManager._state == GameStates.Exploration)
                {
                    FindObjectOfType<InteractablesController>().Interact();
                }
            }
        }
    }
    IEnumerator CrShoot()
    {
        GetComponent<MovementController>().enabled = false;
        _animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.4f);
        electricBall1.transform.position = _shootPosition.transform.position;
        electricBall1.Play();
        GameObject ball = Instantiate(_solarCanonBall, _shootPosition.transform.position, Quaternion.identity);

        EnemyController[] _enemies = FindObjectsOfType<EnemyController>();

        List<float> angles = new List<float>();
        for(int i  =0;i< _enemies.Length; i++)
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
            ball.transform.LookAt(_shootPosition.transform.position + (_enemies[enemyIndex].transform.position - _shootPosition.transform.position).normalized* 2);
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
        GetComponent<MovementController>().enabled = false;
        _animator.SetTrigger("Attack");
        Vector3 startingPosition = transform.position;
        Vector3 targetPosition = transform.position + transform.forward * 5f;
        _spin.SetActive(true);
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
        Vector3 raycastEnd = targetPosition;
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(currentPosition, targetPosition, i / 0.1f);
            yield return null;
        }
        transform.position = targetPosition;
        RaycastHit hitInfo;
        var hits = Physics.RaycastAll(raycastStart, transform.forward, 5);
        foreach(var hit in hits)
        {
            print(hit.collider.gameObject.name);
            if(hit.collider.gameObject.GetComponent<EnemyController>()!=null)
            {
                hit.collider.gameObject.GetComponent<EnemyController>().ReceiveDamage(50);
                break;
            }
        }
        for(float i = 0; i< 0.25f; i += Time.deltaTime)
        {
            _realGoran.transform.localScale = Vector3.Lerp( Vector3.zero,Vector3.one, i/0.25f);
            yield return null;
            _realGoran.transform.localPosition= Vector3.Lerp( Vector3.up*2,Vector3.zero, i/0.25f); 

            //transform.position = Vector3.Lerp(startingPosition, targetPosition, i/0.25f);
        }
        _realGoran.transform.localPosition= Vector3.zero;
        _realGoran.transform.localScale = Vector3.one;
        GetComponent<MovementController>().enabled = true;
        _spin.SetActive(false);
    }
    IEnumerator CrSpin()
    {
        _animator.SetTrigger("Attack");
        _spin.SetActive(true);
        _superRotate = true;
        for(float i =0; i< 1f; i += Time.deltaTime)
        {
            yield return null;
            Collider[] nearEnemyColliders = Physics.OverlapSphere(transform.position, 1.5f, 1 << 8);
            foreach (Collider g in nearEnemyColliders)
            {
                if (g.transform.root.GetComponent<EnemyController>() != null)
                {
                    g.transform.root.GetComponent<EnemyController>().ReceiveDamage(2);
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
