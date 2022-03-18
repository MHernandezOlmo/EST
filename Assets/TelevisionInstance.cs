using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionInstance : MonoBehaviour
{
    List<Vector3> _movePoints;
    List<Transform> _shootoints;
    [SerializeField] bool isMain;
    [SerializeField] float _speed, _minDist, _maxDist, _shootAmount, _ratio;
    [SerializeField] GameObject _shootPrefab;
    private float _moveDist, _currentWaitTime, _waitTime;
    private int _currentPoint, _nextPoint;
    private Coroutine _moveCr;
    private Animator _animator;

    void Start()
    {
        if(transform.parent == null)
        {
            isMain = true;
        }

        if (isMain)
        {
            int pointsAmount = Random.Range(4, 7);
            _animator = GetComponent<Animator>();
            _movePoints = new List<Vector3>();
            _shootoints = new List<Transform>();
            _waitTime = Random.Range(2f, 5f);
            _moveDist = Random.Range(_minDist, _maxDist);

            for (int i = 0; i < _shootAmount; i++)
            {
                float angle = 2 * Mathf.PI / _shootAmount * i;
                float posX = Mathf.Cos(angle) * _ratio;
                float posZ = Mathf.Sin(angle) * _ratio;
                GameObject s = new GameObject();
                s.transform.position= transform.position + (transform.right * posX) + (transform.forward * posZ);
                s.transform.position += Vector3.up;
                s.name = "ShootPoint";
                s.transform.SetParent(transform);
                _shootoints.Add(s.transform);
            }

            for (int i = 0; i < pointsAmount; i++)
            {
                _movePoints.Add(new Vector3(transform.position.x - Random.Range(-_moveDist, _moveDist), transform.position.y, transform.position.z - Random.Range(-_moveDist, _moveDist)));
            }
            _moveCr = StartCoroutine(CrMove());
        }
    }

    private void Update()
    {
        if (isMain)
        {
            Quaternion targetRot = Quaternion.LookRotation(transform.position - _movePoints[_currentPoint]);
            targetRot = Quaternion.Euler(targetRot.eulerAngles.x, targetRot.eulerAngles.y - 90, targetRot.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 5f);

            _currentWaitTime += Time.deltaTime;

            if (_currentWaitTime > _waitTime)
            {
                _currentWaitTime = 0;
                Attack();
            }
        }
    }

    public void Attack()
    {
        if (isMain)
        {
            StopCoroutine(_moveCr);
            _waitTime = Random.Range(2f, 5f);
            _animator.SetTrigger("Attack");
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    public void AttackCallBack()
    {
        if (isMain)
        {
            for (int i = 0; i < _shootAmount; i++)
            {
                GameObject pb = Instantiate(_shootPrefab, _shootoints[i].position, Quaternion.identity);
                Vector3 dir = (_shootoints[i].position - transform.position);
                dir.y = 0;
                pb.transform.LookAt(pb.transform.position + dir);
            }
        }
    }

    public void FinishCallBack()
    {
        if (isMain)
        {
            _moveCr = StartCoroutine(CrMove());
        }
    }


    IEnumerator CrMove()
    {
        float dur = 1f;
        int _nextPoint = _currentPoint + 1;
        _nextPoint %= _movePoints.Count;
        Vector3 startPoint = transform.position;

        dur *= Vector3.Distance(startPoint, _movePoints[_nextPoint]) / _speed;

        for (float i = 0; i < dur; i+= Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPoint, _movePoints[_nextPoint], i / dur);
            yield return null;
        }
        transform.position = _movePoints[_nextPoint];
        _currentPoint = _nextPoint;
        _moveCr = StartCoroutine(CrMove());
    }
}
