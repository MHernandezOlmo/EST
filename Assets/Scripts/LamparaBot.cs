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
    [SerializeField] private bool _moveOnStart;
    PlayerController _playerController;
    private bool _goingBack;
    bool _havePieces;
    bool _canDie;
    bool _dead;
    private Coroutine _moveCr;
    private Vector3 _originPosition;
    private int _lastPoint;
    [SerializeField] private GameObject _deathParticles;
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _animator = GetComponent<Animator>();
        if (_moveOnStart)
        {
            StartMoving();
        }
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
        float dur = 1.5f;
        for(float i = 0; i< dur; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, i / dur);
            yield return null;
        }
        transform.position = targetPosition;
        _animator.SetTrigger("Idle");
        yield return new WaitForSeconds(Random.Range(0.25f,1f));
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
        yield return new WaitForSeconds(0.3f);
        if (distance < 10)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.RobotShot);
            Instantiate(_shootPrefab, _shootPosition.transform.position, Quaternion.identity);
        }
        _animator.SetTrigger("Idle");
        yield return new WaitForSeconds(Random.Range(0.25f,1f));
        _goingBack = !_goingBack;
        StartCoroutine(CrMove());
    }

    public void StartMoving()
    {
        if (_moveCr != null)
        {
            StopCoroutine(_moveCr);
        }
        _moveCr = StartCoroutine(CrMove());
    }

    public void StopMoving()
    {
        if(_moveCr != null)
        {
            StopCoroutine(_moveCr);
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
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SpecialDie);
        Instantiate(_deathParticles, transform.position, Quaternion.identity);
        for (float i = 0; i< 0.25f; i += Time.deltaTime)
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
