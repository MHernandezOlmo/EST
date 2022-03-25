using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVCombatActivator : MonoBehaviour
{
    [SerializeField] GameObject _combatButton;
    CombatCanvasController _combatCanvas;
    [SerializeField] bool _isEinstein;
    bool _firstCombat, fightable;
    TelevisionInstance[] _tvs;
    private int _alivesTv;


    private void Awake()
    {
        _combatCanvas = FindObjectOfType<CombatCanvasController>();
        _tvs = FindObjectsOfType<TelevisionInstance>();
        _alivesTv = _tvs.Length/2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isEinstein)
            {
                if (_firstCombat)
                {
                    EnableCombat();
                }
            }
            else
            {
                EnableCombat();
            }
        }
    }

    public void EnableCombat()
    {
        if(_alivesTv > 0)
        {
            CurrentSceneManager._skillEnabled = true;
            _combatCanvas.Show();
            _combatButton.transform.localScale = Vector3.one;
            _combatButton.SetActive(true);
            _tvs = FindObjectsOfType<TelevisionInstance>();
            foreach (TelevisionInstance t in _tvs)
            {
                t.SetAttackZone(true);
            }
            CurrentSceneManager.SetGameState(GameStates.Combat);
        }
    }

    public void DisableCombat()
    {
        CurrentSceneManager._skillEnabled = false;
        _combatCanvas.Hide();
        _combatButton.SetActive(false);
        foreach (TelevisionInstance t in _tvs)
        {
            t.SetAttackZone(false);
        }
        CurrentSceneManager.SetGameState(GameStates.Exploration);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isEinstein)
            {
                if (_firstCombat)
                {
                    DisableCombat();
                }
            }
            else
            {
                DisableCombat();
            }
        }
    }

    public void KillTv()
    {
        _alivesTv--;
        if(_alivesTv <= 0)
        {
            DisableCombat();
        }
    }

    public void ActiveFirstCombat()
    {
        StartCoroutine(CrWaitForCall());
    }

    public IEnumerator CrWaitForCall()
    {
        yield return new WaitForSeconds(1f);
        EnableCombat();
    }
}
