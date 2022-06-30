using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPriorizer : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    [SerializeField] private CinemachineVirtualCamera _inCam, _midCam, _endCam;
    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        if(_inCam != null && GameProgressController.GetStartPoint() == 1)
        {
            _inCam.Priority = 10;
            _endCam.Priority = 15;
        }
    }

    public void PriorizeCamera()
    {
        _camera.Priority = 200;
    }
    public void StopToPriorize()
    {
        _camera.Priority = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _inCam.Priority = 10;
            _endCam.Priority = 10;
            _midCam.Priority = 15;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.transform.position.z < transform.position.z)
            {
                _inCam.Priority = 15;
                _midCam.Priority = 10;
            }
            else
            {
                _endCam.Priority = 15;
                _midCam.Priority = 10;
            }
        }
    }
}
