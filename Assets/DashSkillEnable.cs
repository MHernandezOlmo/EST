using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    private void OnTriggerEnter(Collider other)
    {
        if (GameProgressController.HasDash())
        {
            CurrentSceneManager.CanDash = true;
            _actionButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameProgressController.HasDash())
        {
            CurrentSceneManager.CanDash = false;
            _actionButton.SetActive(false);
        }
    }

}
