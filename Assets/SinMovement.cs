using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    RectTransform _rectTransform;
    Vector3 _startPosition;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.position;
    }

    void Update()
    {
#if !UNITY_STANDALONE_WIN

        _rectTransform.position = _startPosition+ (Vector3.right* Mathf.Sin(Time.timeSinceLevelLoad*2) * 75);

#endif

    }
}
