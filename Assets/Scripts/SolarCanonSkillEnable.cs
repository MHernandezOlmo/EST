using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonSkillEnable : MonoBehaviour
{
    [SerializeField] GameObject _combatButton;

    private void OnTriggerEnter(Collider other)
    {
        if (GameProgressController.EinsteinSolarCanonSkill)
        {
            if (other.CompareTag("Player"))
            {
                _combatButton.transform.localScale = Vector3.one;
                CurrentSceneManager._skillEnabled = true;
                _combatButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameProgressController.EinsteinSolarCanonSkill)
        {
            if (other.CompareTag("Player"))
            {
                CurrentSceneManager._skillEnabled = false;
                _combatButton.SetActive(false);
            }
        }
    }
}

