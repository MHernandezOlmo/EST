using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActivator : MonoBehaviour
{
    [SerializeField] GameObject _combatButton;
    CombatCanvasController _combatCanvas;
    [SerializeField] bool _isEinstein, _isLomnicky; //En realidad es solo para la escena llegada torre...
    bool _firstCombat;
    TelevisionInstance[] _tvs;
    LamparaBot[] _lamps;
    private int _aliveEnemies;
    private int _sameTimeColliders;

    private void Awake()
    {
        _combatCanvas = FindObjectOfType<CombatCanvasController>();
        if (_isLomnicky)
        {
            _lamps = FindObjectsOfType<LamparaBot>();
            _aliveEnemies = _lamps.Length;
        }
        else
        {
            _tvs = FindObjectsOfType<TelevisionInstance>();
            _aliveEnemies = _tvs.Length / 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sameTimeColliders++;
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
        if(_aliveEnemies > 0)
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
            _sameTimeColliders--;
            if (_isEinstein)
            {
                if (_firstCombat)
                {
                    DisableCombat();
                }
            }
            else if(_sameTimeColliders <= 0)
            {
                DisableCombat();
            }
        }
    }

    public void KillEnemy()
    {
        _aliveEnemies--;
        if(_aliveEnemies <= 0)
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
