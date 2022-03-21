using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonSkillEnable : MonoBehaviour
{
    [SerializeField] GameObject _actionButton, _combatCanvas;
    [SerializeField] bool _isEinsteinTower;
    bool _firstCombat;
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
                if (_isEinsteinTower && _firstCombat)
                {
                    _combatCanvas.SetActive(true);
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
                    _combatCanvas.SetActive(false);
                    foreach (TelevisionInstance t in _tvs)
                    {
                        t.SetAttackZone(false);
                    }
                    CurrentSceneManager.SetGameState(GameStates.Exploration);
                }
            }
        }
    }

    public void ActiveFirstCombat()
    {
        if (GameProgressController.GetHasAO())
        {
            StartCoroutine(CrWaitForCall());
        }
    }

    public IEnumerator CrWaitForCall()
    {
        yield return new WaitForSeconds(1f);
        _firstCombat = true;
        _combatCanvas.SetActive(true);
        _tvs = FindObjectsOfType<TelevisionInstance>();
        foreach (TelevisionInstance t in _tvs)
        {
            t.SetAttackZone(true);
        }
        CurrentSceneManager.SetGameState(GameStates.Combat);
    }
}

