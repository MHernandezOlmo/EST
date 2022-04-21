using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CombatController : MonoBehaviour
{
    CombatTrigger _currentCombatTrigger;
    TransitionsController _transitionsController;
    CinemachineVirtualCamera _mainSceneCamera;
    [SerializeField] private bool _isFreeZone;
    private bool _started;
    
    private void Awake()
    {
        _transitionsController = FindObjectOfType<TransitionsController>();
    }

    public void StartCombat(CombatTrigger newCombatTrigger)
    {
        if (CurrentSceneManager._state != GameStates.Combat)
        {
            _currentCombatTrigger = newCombatTrigger;
            StartCoroutine(CrStartCombat());
            _started = true;
        }
        else if(_isFreeZone && !_started)
        {
            _currentCombatTrigger = newCombatTrigger;
            StartCoroutine(CrStartCombat());
        }
    }
    IEnumerator CrStartCombat()
    {
        _currentCombatTrigger.GetCombatCamera().Priority = 20;
        yield return new WaitForSeconds(1f);
        GameEvents.CombatEvent.Invoke(true);
        GameEvents.ChangeGameState.Invoke(GameStates.Combat);
        _currentCombatTrigger.SpawnEnemies();
    }

    public void EndCombat()
    {
        GameEvents.CombatEvent.Invoke(false);
        if(FindObjectOfType<CombatActivator>() == null)
        {
            print("not found");
            GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
        }
        _currentCombatTrigger.GetCombatCamera().Priority = 5;
    }
}
