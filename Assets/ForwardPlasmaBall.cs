using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPlasmaBall : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.forward * 5 * Time.deltaTime, Space.World);
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
