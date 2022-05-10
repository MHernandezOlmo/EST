using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool _dropsPiece;
    [SerializeField] private bool _lastone;
    [SerializeField] private GameObject _piece;

    CombatTrigger _combatTrigger;
    
    [SerializeField]
    Vector3 _originalScale;
    
    float _maxHP;
    float _currentHP;
    [SerializeField]HPBar _currentHPBar;
    [SerializeField] Transform _hpBarPosition;
    bool _dead, _hitSFXCD;
    
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private GameObject _deathParticles;
    [SerializeField] private  Transform _player;
    public enum EnemyType { Robola, Lamp, TV, Toast, Microwave, Oven}
    [SerializeField] private Animator _animator;

    private void Start()
    {

        if (_enemyType == EnemyType.TV)
        {
            GameObject g = new GameObject();
            g.transform.position = transform.position + Vector3.up * 3;
            g.transform.SetParent(transform);
            _hpBarPosition = g.transform;
        }
        _player = FindObjectOfType<PlayerController>().transform;
        _currentHP = 100;
        _maxHP = 100;
        _originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(Appear());
    }

    public void SetHPBar(HPBar _hp)
    {
        _currentHPBar = _hp;
    }

    public void ReceiveDamage(int value)
    {
        if (!_dead)
        {
            if(_enemyType == EnemyType.Toast && !GameProgressController.HasAllFilters())
            {
                return;
            }
            if (_enemyType == EnemyType.Microwave && !GameProgressController.Tetris)
            {
                return;
            }
            if (_enemyType == EnemyType.Oven && !GameProgressController.Tetris) //TO DO REVISAR 2ª CONDICIÓN
            {
                return;
            }
            if (!_hitSFXCD)
            {
                AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.RobotHit);
                _hitSFXCD = true;
                StartCoroutine(SoundCD());
            }
            _currentHP -= value;
            if (_currentHP <= 0)
            {
                _currentHP = 0;
                _dead = true;
                StartCoroutine(CrDie());
            }
        }
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
                _currentHPBar.UpdateData(_currentHP / _maxHP, _hpBarPosition.position);
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
        if (_dropsPiece)
        {

            if (_lastone)
            {
                if (!GameProgressController.TopPiecePicked)
                {
                    GameProgressController.TopPiecePicked = true;
                    Instantiate(_piece, transform.position + Vector3.up * 1, transform.rotation);
                }
            }
            else
            {
                int totalPieces = GameProgressController.GetPiezasAO() + FindObjectsOfType<PiezaAO>().Length;
                if (GameProgressController.TopPiecePicked)
                {
                    if (totalPieces < 10)
                    {
                        Instantiate(_piece, transform.position + Vector3.up * 1, transform.rotation);
                    }
                }
                else
                {
                    if (totalPieces < 9)
                    {
                        Instantiate(_piece, transform.position + Vector3.up * 1, transform.rotation);
                    }
                }
            }
        }

        if(_enemyType == EnemyType.Robola)
        {
            if (_deathParticles != null)
            {
                AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.BlueEDeath);
                AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.EchoPops);
                Instantiate(_deathParticles, transform.position, Quaternion.identity);
            }
        }
        else if(_enemyType == EnemyType.TV)
        {
            FindObjectOfType<CombatActivator>().KillEnemy();
        }

        _currentHPBar.Stop();    
        _animator.SetTrigger("Dead");
        for (float i = 0; i < 0.15f; i += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(_originalScale, Vector3.zero,  i / 0.15f);
            yield return null;
        }
        transform.localScale = Vector3.zero;
        if(_combatTrigger != null)
        {
            _combatTrigger.AddKill();
        }
        Destroy(gameObject);
    }

    IEnumerator SoundCD()
    {
        yield return new WaitForSeconds(0.5f);
        _hitSFXCD = false;
    }
}
