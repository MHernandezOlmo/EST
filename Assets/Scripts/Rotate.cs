using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Vector3 _rotationRate;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(_rotationRate*Time.deltaTime);
    }
}
