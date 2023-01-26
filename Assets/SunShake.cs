using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunShake : MonoBehaviour
{
    RectTransform rt;
    bool _estabilized;
    float _movingTime;
    Vector2 _targetPosition;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    public void SetEstabilized(bool estabilized)
    {
        _estabilized = estabilized;

    }

    void Update()
    {
        if (_movingTime > 3)
        {
            _targetPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 40;
            _movingTime = 0;
        }

        Vector2 vibrationOffset = Vector2.zero;
        _targetPosition = Vector2.zero;
        if (!_estabilized)
        {
            vibrationOffset = new Vector2(Random.Range(-6, 6), Random.Range(-6, 6));
            _movingTime += Time.deltaTime;
        }
        
        rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, _targetPosition, Time.deltaTime*4) + vibrationOffset;
        
    }
}
