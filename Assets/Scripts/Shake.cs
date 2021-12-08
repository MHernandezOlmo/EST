using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    [SerializeField]
    float _intensity;

    Vector3 _originalPosition;
    void Start()
    {
        _originalPosition = transform.position;    
    }
    private void Update()
    {
        transform.position = _originalPosition + new Vector3(Random.Range(-_intensity, _intensity), Random.Range(-_intensity, _intensity), Random.Range(-_intensity, _intensity));
    }


}
