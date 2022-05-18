using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
