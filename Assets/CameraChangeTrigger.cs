using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraChangeTrigger : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera _newCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _newCamera.Priority = 150;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _newCamera.Priority = 1;
        }
    }
}
