using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject _finalCollider;
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
            _aliveEnemies = _tvs.Length ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sameTimeColliders++;
            if (_isEinstein)
            {
                if (GameProgressController.GetUsedPrismEinstein())
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
        if (GameProgressController.GetUsedPrismEinstein() && SceneManager.GetActiveScene().name == "Einstein_0_alrededores_torre")
        {
            if (_finalCollider != null)
            {
                _finalCollider.gameObject.SetActive(true);
                FindObjectOfType<Einstein0Alrededores>().DisableCombatCollider();
            }
        }

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
