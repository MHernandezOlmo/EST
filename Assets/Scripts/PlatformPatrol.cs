using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
    [SerializeField] Transform _platform;
    [SerializeField] Transform _pointA;
    [SerializeField] Transform _pointB;
    [SerializeField] AnimationCurve _animationCurve;
    [SerializeField] float _patrolTime = 4f;
    [SerializeField] float _delay;



    void Start()
    {
        _patrolTime = 4f;
        StartCoroutine(CrPatrol(_delay));
    }
    
    IEnumerator CrPatrol(float delay)
    {
        
        for(float i = delay; i< _patrolTime; i += Time.deltaTime)
        {
            _platform.transform.position = Vector3.Lerp(_pointA.transform.position, _pointB.transform.position, _animationCurve.Evaluate(i / _patrolTime));
            yield return null;
        }

        for (float i = 0; i < _patrolTime; i += Time.deltaTime)
        {
            _platform.transform.position = Vector3.Lerp( _pointB.transform.position, _pointA.transform.position, _animationCurve.Evaluate(i / _patrolTime));
            yield return null;
        }

        StartCoroutine(CrPatrol(0));
    }
}
