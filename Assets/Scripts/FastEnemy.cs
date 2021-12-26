using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    bool battling;
    public float _shootTime= 5;
    private float _shootElapsedTime;
    [SerializeField] private GameObject _shootPrefab;
    [SerializeField] private Transform _shootPosition;
    Transform _player;
    [SerializeField] GameObject _meshPivot;
    [SerializeField] float _activationDistance=5f;
    [SerializeField] float _shootAnimationTime;
    [SerializeField] private Transform[] _possiblePositions;
    private bool _goingBack;
    private Vector3 _startPosition;
    private bool _randomRotating;
    void Start()
    {
        _startPosition = transform.position;
        _shootTime = 3f;
        _player = FindObjectOfType<PlayerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (battling)
        {
            _meshPivot.transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
            _shootElapsedTime += Time.deltaTime;
            if (_shootElapsedTime > _shootTime)
            {
                _shootElapsedTime = 0f;
                _animator.SetTrigger("Shoot");
                StartCoroutine(CrShoot());
            }
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position); 
            if (distanceToPlayer < _activationDistance)
            {
                battling = true;
                _animator.SetTrigger("Activation");
            }
        }
    }
    IEnumerator CrShoot()
    {
        yield return new WaitForSeconds(_shootAnimationTime);
        Instantiate(_shootPrefab, _shootPosition.position, Quaternion.identity);
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SoftShoot);
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(CrMove());
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(CrMove());
    }

    IEnumerator CrMove()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = _possiblePositions[Random.Range(0, 4)].position;
        _animator.SetBool("Walk", true);
        if (_goingBack)
        {
            targetPosition = _startPosition;
        }
        _randomRotating = true;
        for (float i = 0; i < 0.5; i += Time.deltaTime)
        {    
            transform.position = Vector3.Lerp(startPosition, targetPosition, i / 0.5f);
            yield return 0;
        }

        _randomRotating = false;
        transform.rotation = Quaternion.identity;
        _animator.SetBool("Walk", false);
        _goingBack = !_goingBack;
    }
}
