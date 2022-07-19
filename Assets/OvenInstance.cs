using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenInstance : MonoBehaviour
{
    [SerializeField] private float _detectionDist, _attackDist;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab, _particles;
    private Animator _animator;
    private Transform _player;
    private bool _alerted;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_alerted)
        {
            return;
        }
        if(Vector3.Distance(_player.position, transform.position) < _detectionDist)
        {
            _animator.SetTrigger("Alert");
            _alerted = true;
            StartCoroutine(CrAlerted());
        }
    }

    IEnumerator CrAlerted()
    {
        yield return new WaitForSeconds(1f);
        while (Vector3.Distance(_player.position, transform.position) > _attackDist || CurrentSceneManager._state == GameStates.Dialogue)
        {
            yield return null;
        }
        StartCoroutine(CrAttack());
    }

    IEnumerator CrAttack()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = _player.position - (_player.position - transform.position).normalized * 3f;
        float dist = Vector3.Distance(startPos, targetPos);
        float dur = 1.5f * (dist / 10f);

        float rotDur = 1f;
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = Quaternion.LookRotation(_player.position - transform.position, Vector3.up);
        for (float i = 0; i < rotDur; i += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRot, i / rotDur);
            yield return null;
        }
        transform.rotation = targetRot;

        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.OvenRun);
        _animator.SetTrigger("Run");
        _particles.SetActive(false);
        _particles.SetActive(true);
        for (float i = 0; i < dur; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, i / dur);
            if(i/dur < 0.5f)
            {
                transform.rotation = Quaternion.LookRotation(_player.position - transform.position, Vector3.up);
            }
            yield return null;
        }
        transform.position = targetPos;
        _animator.SetTrigger("Shoot");
    }
    public void ShootCallBack()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.OvenShot);
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        Instantiate(_bulletPrefab, _shootPoint.position + _shootPoint.right * 0.5f, _shootPoint.rotation);
        Instantiate(_bulletPrefab, _shootPoint.position - _shootPoint.right * 0.5f, _shootPoint.rotation);

        Vector3 upOffset = _shootPoint.up * 0.25f;
        Quaternion rotA = Quaternion.Euler(_shootPoint.rotation.eulerAngles.x, _shootPoint.rotation.eulerAngles.y +5f, _shootPoint.rotation.eulerAngles.z);
        Quaternion rotB = Quaternion.Euler(_shootPoint.rotation.eulerAngles.x, _shootPoint.rotation.eulerAngles.y -5f, _shootPoint.rotation.eulerAngles.z);

        Instantiate(_bulletPrefab, _shootPoint.position - upOffset, _shootPoint.rotation);
        Instantiate(_bulletPrefab, _shootPoint.position + _shootPoint.right * 0.5f - upOffset, rotA);
        Instantiate(_bulletPrefab, _shootPoint.position - _shootPoint.right * 0.5f - upOffset, rotB);
    }

    public void AttackCallBack()
    {
        StartCoroutine(CrAlerted());
    }
}
