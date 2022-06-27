using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    private void OnTriggerEnter(Collider other)
    {
        _actionButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _actionButton.SetActive(false);
    }
}
