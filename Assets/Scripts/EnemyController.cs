using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CombatTrigger _combatTrigger;
    
    [SerializeField]
    Vector3 _originalScale;
    
    float _maxHP;
    float _currentHP;
    HPBar _currentHPBar;
    [SerializeField] Transform _hpBarPosition;
    bool _dead;
    
    [SerializeField] private EnemyType _enemyType;

    [SerializeField] private  Transform _player;
    public enum EnemyType { Robola, Lamp, TV}
    [SerializeField] private Animator _animator;
    
    public void SetHPBar(HPBar _hp)
    {
        _currentHPBar = _hp;
    }

    public void ReceiveDamage(int value)
    {
        if (!_dead)
        {
            
            _currentHP -= value;
            if (_currentHP <= 0)
            {
                _currentHP = 0;
                _dead = true;
                StartCoroutine(CrDie());
            }
        }
    }
    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
        _currentHP = 100;
        _maxHP = 100;
        _originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(Appear());
    }

    public IEnumerator Appear()
    {
        for(float i = 0; i< 0.25f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, _originalScale, i/0.25f); 
            yield return null;
        }
        transform.localScale = _originalScale;

    }
    private void Update()
    {
        if (!_dead)
        {
            if (!_player.gameObject.activeSelf)
            {
                 _player= FindObjectOfType<PlayerController>().transform;
            }
            if (_currentHPBar != null)
            {
                _currentHPBar.UpdateData((float)_currentHP / (float)_maxHP, _hpBarPosition.position);
            }
        }
        else
        {
            if (_currentHPBar != null)
            {
                _currentHPBar.gameObject.SetActive(false);    
            }
        }
    }


    public void SetCombatTrigger(CombatTrigger newCombatTrigger)
    {
        _combatTrigger = newCombatTrigger;
    }
    
    IEnumerator CrDie()
    {
        _currentHPBar.Stop();
        
        _animator.SetTrigger("Dead");
        for (float i = 0; i < 0.15f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(_originalScale, Vector3.zero,  i / 0.15f);
            yield return null;
        }
        transform.localScale = Vector3.zero;
        _combatTrigger.AddKill();
        Destroy(gameObject);
    }
}
