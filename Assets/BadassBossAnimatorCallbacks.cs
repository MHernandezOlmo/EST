using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadassBossAnimatorCallbacks : MonoBehaviour
{
    BadassEnemy _enemy;
    void Start()
    {
        _enemy = FindObjectOfType<BadassEnemy>();
    }

    public void StartWalk()
    {
        _enemy.Walking = true;
    }
    public void Attack()
    {
        FindObjectOfType<BadassAttack>().Attack();
    }
    void Update()
    {
        
    }
}
