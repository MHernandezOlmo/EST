using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    private void OnTriggerEnter(Collider other)
    {
        if (GameProgressController.GetHasSolarCanon())
        {
            CurrentSceneManager._skillEnabled = true;
            if (other.CompareTag("Player"))
            {
                _actionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameProgressController.GetHasSolarCanon())
        {
            CurrentSceneManager._skillEnabled = false;
            if (other.CompareTag("Player"))
            {
                _actionButton.SetActive(false);
            }
        }
    }
}

