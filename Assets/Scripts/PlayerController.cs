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
    [SerializeField] GameObject _shieldObject;
    private CameraShake _cameraShake;
    private VignettingController _vignettingController;
    public enum Character {Goran, MsProminence, Flare, Eclipse, None, Spot, Spectro};
    public Character _currentCharacter;
    [SerializeField] GameObject _solarCanonBall;
    float _shootTime;
    float _elapsedShootTime;
    bool isShielding;
    bool isJetpacking;
    [SerializeField] AnimationCurve _animationCurve;
    private Animator _animator;
    private int _currentHp;
    private int _maxHP =300;
    private bool _superRotate, _dead, _underCD, _megaRobot;
    private Coroutine _cDCr;
    public HPBar _currentHPBar;
    float _restoreHP = 0f;
    [SerializeField] GameObject _interactButton;
    [SerializeField] GameObject _combatButton;

    public int GetMaxHP()
    {
        return _maxHP;
    }
    
    public int GetHP()
    {
        return _currentHp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>() != null)
        {
            if (isJetpacking)
            {
                other.GetComponent<EnemyController>().ReceiveDamage(1000);
            }
        }
    }


    public void ReceiveDamage(int newValue)
    {
        if(newValue == 5000)
        {
            _megaRobot = true;
        }
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
            if(_cDCr != null)
            {
                StopCoroutine(_cDCr);
            }
            _cDCr = StartCoroutine(CrCoolDown());
            _currentHPBar.Show();
            _currentHp -= newValue;
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.Hit);
            _cameraShake.ShakeCamera(0.08f, 0.1f);
            _vignettingController.ReceiveHit();
            if (_currentHp <=0)
            {
                _currentHp = 0;
                _dead = true;
                _animator.SetTrigger("Death");
                GetComponent<MovementController>().enabled = false;
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
        _interactButton = FindObjectOfType<InputCanvasController>().InteractButton;
        _combatButton= FindObjectOfType<InputCanvasController>().CombatButton;
        _currentHp = _maxHP;
        _animator = GetComponentInChildren<Animator>();
        _shootTime = 1f;
        _vignettingController = FindObjectOfType<VignettingController>();
        Physics.gravity = Vector3.zero; 
        GameProgressController.SetCurrentScene(SceneManager.GetActiveScene().name);
        StartCoroutine(CrPosition());
    }

    IEnumerator CrWaitForDie()
    {
        yield return new WaitForSeconds(1f);
        if(CurrentSceneManager._state == GameStates.Combat)
        {
            AudioEvents.playDefMusic.Invoke();
        }
        if (_megaRobot)
        {
            if (SceneManager.GetActiveScene().name.Contains("exterior"))
            {
                GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
            }
            else
            {
                GameEvents.LoadScene.Invoke("EST_hall");
            }
        }
        else
        {
            if (FindObjectOfType<CountdownCanvas>() != null)
            {
                FindObjectOfType<CountdownCanvas>().Restart();
            }
            else
            {

                GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
            }
        }
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
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up * -1, out hit, 10))
        {
            if(hit.collider.gameObject.layer == 4)
            {
                if (!isJetpacking) ReceiveDamage(9999);
            }
        }
        if (!_dead)
        {
            if (!_underCD)
            {
                _restoreHP += Time.deltaTime * 10;
                if (_restoreHP >= 1)
                {
                    _currentHp++;
                    _restoreHP = 0;
                }
                if (_currentHp > _maxHP)
                {
                    _currentHp = _maxHP;
                }
            }
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

            if(!_combatButton.activeSelf && _interactButton.activeSelf)
            {
                FindObjectOfType<InteractablesController>().Interact();
            }

            if (_combatButton.activeSelf && _interactButton.activeSelf)
            {
                FindObjectOfType<InteractablesController>().Interact();
            }
            if (_combatButton.activeSelf && !_interactButton.activeSelf)
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
                if (_currentCharacter == Character.Spot)
                {
                    if (GameProgressController.GregorJetpackSkill)
                    {
                        if (CurrentSceneManager._canJetpack)
                        {
                            CurrentSceneManager._canJetpack = false;
                            if (!isJetpacking)
                            {
                                StartCoroutine(CrUseJetpack());
                            }
                        }
                    }

                }
                if (_currentCharacter == Character.MsProminence)
                {
                    if (CurrentSceneManager.CanDash)
                    {
                        if (GameProgressController.PicDuMidiDashSkill)
                        {
                            CurrentSceneManager.CanDash = false;
                            StartCoroutine(CrDash());
                        }
                    }
                }
                if (_currentCharacter == Character.Flare)
                {
                    if (_elapsedShootTime > _shootTime)
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
        
        _animator.SetBool("IsShieldUp", true);
        GetComponent<MovementController>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        _shield.SetActive(true);
        _shieldObject.SetActive(true);
        if (electricBall1 != null)
        {
            electricBall1.Play();
        }

        for(float i = 0; i<0.1f; i += Time.deltaTime)
        {
            _shield.transform.localScale = Vector3.one * _animationCurve.Evaluate((i / 0.1f)); ;
            yield return null;
        }
        _shield.transform.localScale = Vector3.one;
        isShielding = true;
        yield return new WaitForSeconds(0.8f);
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            _shield.transform.localScale = Vector3.one- Vector3.one * _animationCurve.Evaluate((i / 0.1f));
            yield return null;
        }
        _shield.transform.localScale = Vector3.zero;
        _animator.SetBool("IsShieldUp", false);

        _shield.SetActive(false);
        _shieldObject.SetActive(false);
        _shield.transform.localScale = Vector3.one;
        isShielding = false;
        GetComponent<MovementController>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        CurrentSceneManager._canShield = true;
    }
    IEnumerator CrUseJetpack()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.JetIgnition);
        _animator.SetBool("IsJetpacking", true);
        yield return new WaitForSeconds(0.1f);
        _shield.SetActive(true);

        CurrentSceneManager._isJetpacking = true;
        isJetpacking= true;
        yield return new WaitForSeconds(2f);
        _animator.SetBool("IsJetpacking", false);
        isJetpacking = false;
        CurrentSceneManager._isJetpacking = false;
        _shield.SetActive(false);


        yield return new WaitForSeconds(0.3f);
        CurrentSceneManager._canJetpack = true;
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
                if (!hit.collider.isTrigger)
                {
                    targetPosition = hit.point - (hit.point - raycastStart).normalized;
                }
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

    IEnumerator CrCoolDown()
    {
        _underCD = true;
        yield return new WaitForSeconds(1f);
        _underCD = false;
    }
}
