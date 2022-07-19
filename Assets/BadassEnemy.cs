using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadassEnemy : MonoBehaviour
{
    public Animator _animatorController;
    public Animator _animatorControllerEnemies;
    public GameObject _BossMesh;
    [SerializeField] private float _speed;
    PlayerController _player;
    bool _walking;
    public bool Walking
    {
        get
        {
            return _walking;
        }
        set
        {
            _walking = value;
        }
    }

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();   
    }

    public void StartAnimation()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.MegaAnimation);
        _animatorControllerEnemies.Play("EnemyCollection");
    }
    public void ActivateBadassBoss()
    {
        _BossMesh.SetActive(true);
    }

    
    void Update()
    {
        if (_walking)
        {
            Vector3 dir = _player.transform.position - transform.position;
            transform.Translate(dir.normalized * _speed*Time.deltaTime);
        }
    }
}
