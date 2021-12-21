using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerFollow : MonoBehaviour
{
    private Transform _player;
    private bool _checking;

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            transform.position = _player.position;
        }
        else if (!_checking)
        {
            StartCoroutine(SearchPlayer());
        }
    }

    IEnumerator SearchPlayer() 
    {
        _checking = true;
        while (!FindObjectOfType<PlayerMovement>())
        {
            yield return null;
        }
        _player = FindObjectOfType<PlayerMovement>().transform;
        _checking = false;
    }
}
