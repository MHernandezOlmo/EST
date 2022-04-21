using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPlasmaBall : MonoBehaviour
{
    [SerializeField] private bool _isToast;
    [SerializeField] private float _speed;

    private void Start()
    {
        if(_speed == 0)
        {
            _speed = 9f;
        }
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
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(20);
            }
            Destroy(gameObject);
        }
    }

}
