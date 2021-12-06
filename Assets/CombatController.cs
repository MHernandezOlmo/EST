using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CombatController : MonoBehaviour
{
    CombatTrigger _currentCombatTrigger;
    TransitionsController _transitionsController;
    CinemachineVirtualCamera _mainSceneCamera;
    private void Awake()
    {
        _transitionsController = FindObjectOfType<TransitionsController>();
    }

    public void StartCombat(CombatTrigger newCombatTrigger)
    {
        if (CurrentSceneManager._state != GameStates.Combat)
        {
            print("Intento entrar");
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
        GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
        _currentCombatTrigger.GetCombatCamera().Priority = 5;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
