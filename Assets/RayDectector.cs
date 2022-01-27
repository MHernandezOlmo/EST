using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDectector : MonoBehaviour
{
    [SerializeField] LineRenderer _lRenderer;
    [SerializeField] LayerMask _mask;
    [SerializeField] int _posIndex;
    Vector3 initialPoint;
    bool detected;

    private void Start()
    {
        initialPoint = _lRenderer.GetPosition(_posIndex);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit, Mathf.Infinity, _mask))
        {
            _lRenderer.SetPosition(_posIndex, hit.point);
            detected = true;
        }
        else if(detected)
        {
            _lRenderer.SetPosition(_posIndex, initialPoint);
            detected = false;
        }
    }
}
