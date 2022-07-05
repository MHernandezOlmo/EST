using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMicroWave : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    Transform _player;
    Vector3 _startSize;
    private float _startDegrees;
    bool canBeSeen;
    private int _currentMove;
    Quaternion _startRot;
    [SerializeField] private int _maxSteps =2;
    private int _steps;
    private Animator _animator;
    [SerializeField] Material _blueFresnel;

    private void Awake()
    {
        _startRot = transform.rotation;
        _startSize = transform.localScale;
    }

    void Start()
    {
        _startDegrees = transform.rotation.eulerAngles.y;
        _player = FindObjectOfType<PlayerController>().transform;
        _animator = GetComponent<Animator>();
        if (GameProgressController.SSTPuzzleTetrisAO)
        {
            canBeSeen = true;
        }
        if (!canBeSeen)
        {
            Material[] mats = new Material[_meshRenderer.materials.Length];
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = _blueFresnel;
            }
            _meshRenderer.materials = mats;
        }
        StartCoroutine(CrMove());
    }

    public void Update()
    {
        if (!canBeSeen)
        {
            transform.localScale = _startSize * Random.Range(0.9f, 1.1f);
        }
    }


    IEnumerator CrMove()
    {
        yield return new WaitForSeconds(0.5f);
        float rotDur = 0.5f;
        float movDur = 0.4f;

        if(Random.value < 0.5f)
        {
            if (_steps -1 < -_maxSteps)
            {
                _steps++;
                _currentMove = 1;
            }
            else
            {
                _steps--;
                _currentMove = 0;
            }
        }
        else
        {
            if (_steps + 1 > _maxSteps)
            {
                _steps--;
                _currentMove = 0;
            }
            else
            {
                _steps++;
                _currentMove = 1;
            }
        }

        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(transform.rotation.eulerAngles.x, _startDegrees + 180 * _currentMove, transform.rotation.eulerAngles.z);

        for (float i = 0; i < rotDur; i += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, i / rotDur);
            yield return null;
        }
        transform.rotation = targetRot;
        yield return new WaitForSeconds(0.5f);

        _animator.SetTrigger("Jump");
        yield return new WaitForSeconds(0.1f);
        Vector3 startPos = transform.position;
        RaycastHit hit;
        Physics.Raycast(transform.position + transform.forward*2f + Vector3.up*2, Vector3.down,out hit,10,1<<14);

        Vector3 targetPos = hit.point + Vector3.up * 0.1f;

        for (float i = 0; i < movDur; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, i / movDur);
            yield return null;
        }
        transform.position = targetPos;

        if (Vector3.Distance(transform.position, _player.position) < 15)
        {
            yield return new WaitForSeconds(0.5f);
            if (CurrentSceneManager._state != GameStates.Dialogue)
            {
                StartCoroutine(CrAttack());
            }
            else
            {
                StartCoroutine(CrMove());
            }
        }
        else
        {
            StartCoroutine(CrMove());
        }
    }

    IEnumerator CrAttack()
    {
        float rotDur = 0.5f;
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.LookRotation(_player.position - transform.position, Vector3.up);
        for (float i = 0; i < rotDur; i += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, i / rotDur);
            yield return null;
        }
        transform.rotation = targetRot;
        _animator.SetTrigger("Shoot");
    }

    public void ShootCallBack()
    {
        Vector3 diffA = _shootPoint.right * 0.5f;
        Vector3 diffB = _shootPoint.right * -0.5f;
        Instantiate(_bulletPrefab, _shootPoint.position + diffA, _shootPoint.rotation);
        Instantiate(_bulletPrefab, _shootPoint.position + diffB, _shootPoint.rotation);
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }

    public void AttackCallBack()
    {
        StartCoroutine(CrMove());
    }
    public void EnableCombat()
    {
        FindObjectOfType<EnemyHPPool>().AddBar(GetComponent<EnemyController>());
    }
}
