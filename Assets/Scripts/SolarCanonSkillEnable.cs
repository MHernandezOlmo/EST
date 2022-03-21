using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonSkillEnable : MonoBehaviour
{
    [SerializeField] GameObject _actionButton;
    [SerializeField] bool _isEinsteinTower;
    TelevisionInstance[] _tvs;
    private void OnTriggerEnter(Collider other)
    {
        if (GameProgressController.GetHasSolarCanon())
        {
            if (other.CompareTag("Player"))
            {
                CurrentSceneManager._skillEnabled = true;
                _actionButton.SetActive(true);
                _actionButton.transform.localScale = Vector3.one;
                if (_isEinsteinTower)
                {
                    _tvs = FindObjectsOfType<TelevisionInstance>();
                    foreach(TelevisionInstance t in _tvs)
                    {
                        t.SetAttackZone(true);
                    }
                    CurrentSceneManager.SetGameState(GameStates.Combat);
                }
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
                if (_isEinsteinTower)
                {
                    foreach (TelevisionInstance t in _tvs)
                    {
                        t.SetAttackZone(false);
                    }
                    CurrentSceneManager.SetGameState(GameStates.Exploration);
                }
            }
        }
    }
}

