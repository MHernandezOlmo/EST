using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparaBot : MonoBehaviour
{
    Animator _animator;
    [SerializeField] GameObject[] _movePositions;
    [SerializeField] GameObject _shootPrefab;
    [SerializeField] GameObject _shootPosition;
    [SerializeField] Material _invisibleMaterial;
    [SerializeField] Material _realMaterial;
    [SerializeField] SkinnedMeshRenderer _skmr;
    PlayerController _playerController;
    private bool _goingBack;
    bool _moving;
    bool _havePieces;
    bool _canDie;
    bool _dead;
    private Vector3 _originPosition;
    private int _lastPoint;
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _animator = GetComponent<Animator>();

        _originPosition = transform.position;
        if (GameProgressController.LomnickyPuzzleLayers)
        {
            _skmr.material = _realMaterial;
            _canDie = true;
        }
        else
        {
            _skmr.material = _invisibleMaterial;
            _canDie = false;
        }
        
    }

    public IEnumerator CrMove()
    {
        _animator.SetTrigger("Move");
        int targetPoint = Random.Range(0, _movePositions.Length);
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = _movePositions[targetPoint].transform.position;
        if (_goingBack)
        {
            targetPosition = _originPosition;
        }

        for(float i = 0; i< 2; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, i / 2f);
            yield return null;
        }
        transform.position = targetPosition;
        _animator.SetTrigger("Idle");
        yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        _animator.SetTrigger("Alert");
        float distance = (_playerController.transform.position - transform.position).magnitude;
        
        yield return new WaitForSeconds(0.3f);
        if (distance < 10)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.RobotShot);
            Instantiate(_shootPrefab, _shootPosition.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.3f);
        if (distance < 10)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.RobotShot);
            Instantiate(_shootPrefab, _shootPosition.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.3f);
        if (distance < 10)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.RobotShot);
            Instantiate(_shootPrefab, _shootPosition.transform.position, Quaternion.identity);
        }
        _animator.SetTrigger("Idle");
        yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        _goingBack = !_goingBack;
        StartCoroutine(CrMove());
    }

    void Update()
    {
        if (CurrentSceneManager._state == GameStates.Exploration && CurrentSceneManager._elapsedSceneTime >3f)
        {
            if (!_moving)
            {
                _moving = true;
                StartCoroutine(CrMove());
            }
        }
    }

    public void Die()
    {
        if (_canDie)
        {
            if (!_dead)
            {
                _dead = true;
                StartCoroutine(CrDie());
            }
        }

    }

    IEnumerator CrDie()
    {
        Vector3 localScale = transform.localScale;
        for(float i = 0; i< 0.25f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(localScale, Vector3.zero, i / 0.25f);
            yield return null;
        }
        if(FindObjectOfType<CombatActivator>() != null)
        {
            FindObjectOfType<CombatActivator>().KillEnemy();
        }
        Destroy(gameObject);
    }
}
