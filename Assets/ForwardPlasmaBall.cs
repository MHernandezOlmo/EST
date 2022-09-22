using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPlasmaBall : MonoBehaviour
{
    [SerializeField] private bool _isToast;
    [SerializeField] private float _speed;
    Vector3 _dir;
    PlayerController _player;
    bool _ally;
    public int _damage = 30;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        if (_speed == 0)
        {
            _speed = 9f;
        }
        _dir = ((_player.transform.position + Vector3.up) - transform.position).normalized;
    }

    void Update()
    {
        if (_isToast)
        {
            transform.Translate(transform.up * _speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Player") && !_ally)
            {
                collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(_damage);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().ReceiveDamage(_damage);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Shield"))
        {
            _dir *= -1;
            _ally = true;
        }
        if (collision.gameObject.CompareTag("Enemy") && _ally)
        {
            collision.gameObject.GetComponent<EnemyController>().ReceiveDamage(20);
            Destroy(gameObject);
        }
    }
}
