using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunShake : MonoBehaviour
{
    RectTransform rt;
    bool _estabilized;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    public void SetEstabilized(bool estabilized)
    {
        _estabilized = estabilized;
        if (_estabilized)
        {
            rt.anchoredPosition = Vector2.zero;
        }
    }

    void Update()
    {
        if (!_estabilized)
        {
            rt.anchoredPosition =new Vector2(Random.Range(-6, 6), Random.Range(-6, 6));
        }
        
    }
}
