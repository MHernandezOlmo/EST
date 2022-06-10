using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperBall : MonoBehaviour
{
    Vector3 target;
    [SerializeField] private ParticleSystem _explosion;
    float y;
    PlayerController _player;
    public void SetTarget(Vector3 target)
    {
        y =target.y;
        transform.LookAt(target);
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        GetComponentInChildren<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);
        if(Vector3.Distance(_player.transform.position , transform.position) < 1f)
        {
            _player.ReceiveDamage(100000);
        }
        _explosion.Play();
    }

}
