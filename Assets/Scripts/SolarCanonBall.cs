using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonBall : MonoBehaviour
{
    PlayerController _player;
    Vector3 _dir;
    float elapsedTime;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().ReceiveDamage(100);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        transform.position += transform.forward* Time.deltaTime * 10;
        if (elapsedTime > 10)
        {
            Destroy(gameObject);
        }
    }
}
