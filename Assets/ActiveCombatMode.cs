using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCombatMode : MonoBehaviour
{
    [SerializeField] GameObject _combatTrigger;
    public void ActiveCombat()
    {
        _combatTrigger.SetActive(true);
    }
}
