using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LoopsBehaviour : MonoBehaviour
{
    private bool _rotating;
    private BoxCollider _collider;
    private bool _hunted;
    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
    }

    public void Play()
    {
        if (!_rotating)
        {
            _hunted = false;
            StartCoroutine(CrRotate());    
        }
    }

    public void OnMouseDown()
    {
        if (!_hunted)
        {
            _hunted = true;
            FindObjectOfType<CazaFlaresController>().NotifyLoop();
        }
    }

    IEnumerator CrRotate()
    {
        _rotating = true;
        _collider.enabled = true;
        yield return new WaitForSeconds(2f);
        _rotating = false;
        yield return new WaitForSeconds(1f);
        _collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Play();
        }
        if (_rotating)
        {
            transform.Rotate(180*Time.deltaTime*Vector3.forward);
        }   
    }
}
