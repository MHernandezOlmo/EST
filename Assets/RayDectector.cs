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
    [SerializeField] private bool isMainRay;
    SalaEspectropolarimetroSceneController controller; 
    private void Start()
    {
        initialPoint = _lRenderer.GetPosition(_posIndex);
        controller = FindObjectOfType<SalaEspectropolarimetroSceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.position + transform.forward * 1000, Color.green);
        if (Physics.Raycast(transform.position,transform.forward, out hit, Mathf.Infinity, _mask))
        {
            
            _lRenderer.SetPosition(_posIndex, hit.point);
            detected = true;
            if (isMainRay)
            {
                controller.RayBlocked = true;
            }
        }
        else if(detected)
        {
            _lRenderer.SetPosition(_posIndex, initialPoint);
            if (isMainRay)
            {
                controller.RayBlocked = false;
            }
            detected = false;
        }
    }
}
