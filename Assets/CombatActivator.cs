using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatActivator : MonoBehaviour
{
    [SerializeField] GameObject _combatButton;
    CombatCanvasController _combatCanvas;
    [SerializeField] bool _isEinsteinTower, _isLomnicky, _isToastie, _isMicrowave, _sst;
    bool _firstCombat, _canFight;
    TelevisionInstance[] _tvs;
    LamparaBot[] _lamps;
    FastEnemy[] _fastEnemies;
    ToastieInstance[] _toasties;
    EnemyMicroWave[] _microwaves;
    private int _aliveEnemies;
    private int _sameTimeColliders;
    [SerializeField] private GameObject _finalCollider;
    private void Awake()
    {
        _combatCanvas = FindObjectOfType<CombatCanvasController>();
        _canFight = true;
        if (_isLomnicky)
        {
            _lamps = FindObjectsOfType<LamparaBot>();
            _aliveEnemies = _lamps.Length;
        }
        else if(_isToastie)
        {
            _toasties = FindObjectsOfType<ToastieInstance>();
            _aliveEnemies = _toasties.Length;
            if (!GameProgressController.HasAllPicDuMidiFilters())
            {
                _canFight = false;
            }
        }
        else if(!_isMicrowave)
        {
            _tvs = FindObjectsOfType<TelevisionInstance>();
            _aliveEnemies = _tvs.Length;
        }
        else
        {
            _microwaves = FindObjectsOfType<EnemyMicroWave>();
            _aliveEnemies = _microwaves.Length;
            if (!GameProgressController.GetHasShield())
            {
                _canFight = false;
            }
            if (_sst)
            {
                _fastEnemies = FindObjectsOfType<FastEnemy>();
                _aliveEnemies += _fastEnemies.Length;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sameTimeColliders++;
            if (_isEinsteinTower)
            {
                if (GameProgressController.EinsteinUsedPrism)
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
            if (_canFight)
            {
                _combatButton.transform.localScale = Vector3.one;
                _combatButton.SetActive(true);
            }
            if (!_isLomnicky)
            {
                if (_isToastie)
                {
                    _toasties = FindObjectsOfType<ToastieInstance>();
                    foreach (ToastieInstance t in _toasties)
                    {
                        t.EnableCombat();
                    }
                }
                else if(!_isMicrowave)
                {
                    _tvs = FindObjectsOfType<TelevisionInstance>();
                    foreach (TelevisionInstance t in _tvs)
                    {
                        t.SetAttackZone(true);
                    }
                }
                else
                {
                    _microwaves = FindObjectsOfType<EnemyMicroWave>();
                    foreach (EnemyMicroWave m in _microwaves)
                    {
                        m.EnableCombat();
                    }
                    foreach (FastEnemy l in _fastEnemies)
                    {
                        l.EnableCombat();
                    }
                }
            }
            CurrentSceneManager.SetGameState(GameStates.Combat);
        }
    }

    public void DisableCombat()
    {
        CurrentSceneManager._skillEnabled = false;
        FindObjectOfType<EnemyHPPool>().DisableBars();
        _combatCanvas.Hide();
        _combatButton.SetActive(false);
        if (!_isLomnicky)
        {
            if (!_isToastie)
            {
                if (_tvs!= null)
                {
                    foreach (TelevisionInstance t in _tvs)
                    {
                        t.SetAttackZone(false);
                    }
                }
                    
            }
        }
        CurrentSceneManager.SetGameState(GameStates.Exploration);
        if (GameProgressController.EinsteinUsedPrism && SceneManager.GetActiveScene().name == "Einstein_0_alrededores_torre")
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
            if (_isEinsteinTower)
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
