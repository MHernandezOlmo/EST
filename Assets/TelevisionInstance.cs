using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionInstance : MonoBehaviour
{
    [SerializeField] Transform[] _movePoints;
    [SerializeField] float _speed;
    private int _currentPoint, _nextPoint;

    void Start()
    {
        if(_movePoints.Length > 0)
        {
            StartCoroutine(CrMove());
        }
    }

    private void Update()
    {
        if (_movePoints.Length > 0)
        {
            Quaternion targetRot = Quaternion.LookRotation(transform.position - _movePoints[_currentPoint].position);
            targetRot = Quaternion.Euler(targetRot.eulerAngles.x, targetRot.eulerAngles.y - 90, targetRot.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }
    }


    IEnumerator CrMove()
    {
        float dur = 1f;
        int _nextPoint = _currentPoint + 1;
        _nextPoint %= _movePoints.Length;

        dur *= Vector3.Distance(_movePoints[_currentPoint].position, _movePoints[_nextPoint].position) / _speed;

        for (float i = 0; i < dur; i+= Time.deltaTime)
        {
            transform.position = Vector3.Lerp(_movePoints[_currentPoint].position, _movePoints[_nextPoint].position, i / dur);
            yield return null;
        }
        transform.position = _movePoints[_nextPoint].position;
        _currentPoint = _nextPoint;
        StartCoroutine(CrMove());
    }
}
