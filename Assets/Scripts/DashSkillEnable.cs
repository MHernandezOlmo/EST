using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    private void OnTriggerEnter(Collider other)
    {
        CurrentSceneManager.CanDash = true;
        _actionButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentSceneManager.CanDash = false;
        _actionButton.SetActive(false);
    }
}
