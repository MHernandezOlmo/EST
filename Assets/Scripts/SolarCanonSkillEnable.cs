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
            if (other.CompareTag("Player"))
            {
                CurrentSceneManager._skillEnabled = true;
                _actionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (GameProgressController.GetHasSolarCanon())
        {
            if (other.CompareTag("Player"))
            {
                CurrentSceneManager._skillEnabled = false;
                _actionButton.SetActive(false);
            }
        }
    }
}

