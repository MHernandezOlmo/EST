﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastieInstance : MonoBehaviour
{
    [SerializeField] private GameObject _toastPrefab;
    [SerializeField] private Transform _shootPoint;
    Transform _player;
    Transform bullet;
    private Animator _animator, _shootAnim;
    private int _currentMoves;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
        _animator = GetComponent<Animator>();
        _shootAnim = _shootPoint.GetComponent<Animator>();
        StartCoroutine(CrMove());
    }

    IEnumerator CrMove()
    {
        yield return new WaitForSeconds(0.5f);
        float rotDur = 0.75f;
        float movDur = 0.75f;
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0,90 * _currentMoves, 0);
        _currentMoves++;
        _currentMoves %= 4;

        for (float i = 0; i < rotDur; i+= Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, i / rotDur);
            yield return null;
        }
        transform.rotation = targetRot;
        yield return new WaitForSeconds(0.5f);

        _animator.SetTrigger("Jump");
        yield return new WaitForSeconds(0.25f);
        Vector3 startPos = transform.position;
        Vector3 targetPos = transform.position + transform.forward * 2f;

        for (float i = 0; i < movDur; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, i/movDur);
            yield return null;
        }
        transform.position = targetPos;

        if(Vector3.Distance(transform.position, _player.position) < 15)
        {
            _shootAnim.Play("CreateToast");
            bullet = Instantiate(_toastPrefab, _shootPoint.position, _shootPoint.rotation).transform;
            bullet.SetParent(_shootPoint);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(CrAttack());
        }
        else
        {
            StartCoroutine(CrMove());
        }
    }

    IEnumerator CrAttack()
    {
        float rotDur = 0.5f;
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.LookRotation(_player.position - transform.position, Vector3.up);
        for (float i = 0; i < rotDur; i += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, i / rotDur);
            yield return null;
        }
        transform.rotation = targetRot;
        _animator.SetTrigger("Shoot");
        bullet.rotation = targetRot;
    }

    public void ShootCallBack()
    {
        StartCoroutine(CrToast());
    }

    IEnumerator CrToast()
    {
        bullet.SetParent(null);
        bullet.rotation = Quaternion.Euler(90, bullet.rotation.eulerAngles.y, bullet.rotation.eulerAngles.z);
        bullet.position += bullet.forward * 0.1f;
        bullet.position += bullet.up * 0.1f;
        bullet.GetComponent<ForwardPlasmaBall>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        bullet.GetComponent<BoxCollider>().enabled = true;
    }

    public void AttackCallBack()
    {
        StartCoroutine(CrMove());
    }
}
