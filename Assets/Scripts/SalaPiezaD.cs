using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaPiezaD : MonoBehaviour
{
    bool b1, b2;
    [SerializeField] GameObject _jaula;
    Vector3 _startingPosition;
    
    bool _done;
    public void SetButton(int b)
    {
        if (b == 0)
        {
            b1 = true;
        }
        else
        {
            b2 = true;
        }
    }
    void Start()
    {
        _startingPosition = _jaula.transform.position;
    }

    void Update()
    {
        if (!_done && b1 && b2)
        {
            _done = true;
            
            StartCoroutine(MoveJaula());
        }
        
    }
    IEnumerator MoveJaula()
    {
        for(float i = 0; i<2f; i += Time.deltaTime)
        {
            yield return null;
            _jaula.transform.position = Vector3.Lerp(_startingPosition, _startingPosition + Vector3.up * 5, i / 2f);
        }
    }
}
