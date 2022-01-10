using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepZoneController : MonoBehaviour
{
    [SerializeField] private AudioClip _inClip, _outClip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInChildren<StepsSFXManager>() != null)
        {
            other.GetComponentInChildren<StepsSFXManager>().SetStepClip(_inClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInChildren<StepsSFXManager>() != null)
        {
            other.GetComponentInChildren<StepsSFXManager>().SetStepClip(_outClip);
        }
    }
}
