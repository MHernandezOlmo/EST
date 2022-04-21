using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMicroWave : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    Transform _player;
    Vector3 _startPosition;
    private float _startDegrees;
    bool canBeSeen;
    private int _currentMove;
    private int _steps, _maxSteps = 2;
    private Animator _animator;
    [SerializeField] Material _blueFresnel;
    void Start()
    {
        _startDegrees = transform.rotation.eulerAngles.y;
        _player = FindObjectOfType<PlayerController>().transform;
        _animator = GetComponent<Animator>();
        if (GameProgressController.GetHasAO())
        {
            canBeSeen = true;
        }
        if (!canBeSeen)
        {
            SkinnedMeshRenderer sk = GetComponentInChildren<SkinnedMeshRenderer>();
            for(int i =0; i<sk.materials.Length; i++)
            {
                sk.materials[i] = _blueFresnel;
            }
        }
        _startPosition = transform.position;
        StartCoroutine(CrMove());
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
        Quaternion targetRot = Quaternion.Euler(0, _startDegrees + 180 * _currentMove, 0);


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
        Vector3 targetPos = transform.position + transform.forward * 2f;

        for (float i = 0; i < movDur; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, i / movDur);
            yield return null;
        }
        transform.position = targetPos;

        if (Vector3.Distance(transform.position, _player.position) < 15)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(CrAttack());
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
        Quaternion diffA = Quaternion.Euler(_shootPoint.rotation.eulerAngles.x, _shootPoint.rotation.eulerAngles.y + 5, _shootPoint.rotation.eulerAngles.z);
        Quaternion diffB = Quaternion.Euler(_shootPoint.rotation.eulerAngles.x, _shootPoint.rotation.eulerAngles.y - 5, _shootPoint.rotation.eulerAngles.z);
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        Instantiate(_bulletPrefab, _shootPoint.position, diffA);
        Instantiate(_bulletPrefab, _shootPoint.position, diffB);
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
