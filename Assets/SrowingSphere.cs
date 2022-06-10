using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrowingSphere : MonoBehaviour
{

    float _elapsedTime;
    
    void Update()
    {
        _elapsedTime += Time.deltaTime*5;

        transform.localScale = Vector3.one * (_elapsedTime%2);
        if (_elapsedTime >= 10)
        {
            _elapsedTime = 0f;
        }
    }
}
