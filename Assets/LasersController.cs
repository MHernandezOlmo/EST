using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersController : MonoBehaviour
{
    [SerializeField] private GameObject[] _lasers1;
    [SerializeField] private GameObject[] _lasers2;
    float _elapsedLaser1;
    bool _lasers1On;
    bool _lasers2On;
    void Start()
    {
        
    }

    
    void Update()
    {
        _elapsedLaser1 += Time.deltaTime;
        if(_elapsedLaser1 >= 2f)
        {
            _elapsedLaser1 = 0;
            for(int i = 0; i< _lasers1.Length; i++)
            {
                _lasers1[i].SetActive(_lasers1On);
            }
            for (int i = 0; i < _lasers2.Length; i++)
            {
                _lasers2[i].SetActive(!_lasers1On);
            }
            _lasers1On = !_lasers1On;
        }
        
    }
}
