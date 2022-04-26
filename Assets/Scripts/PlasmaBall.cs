using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBall : MonoBehaviour
{
    PlayerController _player;
    Vector3 _dir;
    float elapsedTime;
    public bool _ally;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _dir = ((_player.transform.position+Vector3.up) - transform.position).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(20);
            }
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            _dir *= -1;
            _ally = true;
        }

        if (!_ally) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().ReceiveDamage(20);
            Destroy(gameObject);
        }

    }
    void Update()
    {
        transform.LookAt(transform.position+_dir);
        elapsedTime += Time.deltaTime;
        transform.position += _dir * Time.deltaTime * 15;
        if (elapsedTime > 5)
        {
            Destroy(gameObject);
        }
    }
}
