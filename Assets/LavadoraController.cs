using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavadoraController : MonoBehaviour
{
    float _elapsedTime;
    [SerializeField] bool turnRight;
    void Start()
    {
        
    }
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= 1f)
        {
            _elapsedTime = 0;

            turnRight = !turnRight;
        }

        if (turnRight)
        {
            transform.Rotate(0,10f*Time.deltaTime,0);
        }
        else
        {
            transform.Rotate(0, -10f * Time.deltaTime, 0);
        }
    }
}
