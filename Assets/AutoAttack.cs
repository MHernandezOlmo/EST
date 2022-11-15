using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    float _elapsedTime;
    void Start()
    {
        
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > 2f)
        {
            FindObjectOfType<BadassAttack>().Attack();
            _elapsedTime = 0f;
        }
    }
}
