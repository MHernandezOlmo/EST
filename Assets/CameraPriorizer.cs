using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPriorizer : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void PriorizeCamera()
    {
        _camera.Priority = 200;
    }
    public void StopToPriorize()
    {
        _camera.Priority = 0;
    }
}
