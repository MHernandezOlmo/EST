using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTV : MonoBehaviour
{
    bool _fighting;
    float _elapsedTime;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _shootPrefab;
    [SerializeField] GameObject[] _shootPositions;
    Vector3 _direction;
    [SerializeField] bool _mmoving;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _direction = transform.right;
    }

    public void Attack()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.RobotShot);
        for(int i = 0; i< _shootPositions.Length; i++)
        {
            GameObject pb = Instantiate(_shootPrefab, _shootPositions[i].transform.position, Quaternion.identity);
            Vector3 dir = (_shootPositions[i].transform.position - transform.position);
            dir.y = 0;
            pb.transform.LookAt(pb.transform.position + dir);
        }
    }
    public void StartWaling()
    {
        if (_mmoving)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, Random.Range(0, 360), transform.rotation.z);
        }
        _elapsedTime = 0f;
        _fighting = false;
    }
    void Update()
    {
        
        if (!_fighting)
        {
            if (_mmoving)
            {
                transform.Translate(_direction * 0.1f * Time.deltaTime);
            }
            
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > 5)
            {
                _fighting = true;
                _animator.SetTrigger("Attack");
                _elapsedTime = 0f;
            }
        }
    }
}
