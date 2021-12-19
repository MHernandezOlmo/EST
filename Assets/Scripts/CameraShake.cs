using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform _target;
    private bool _shaking;
    CinemachineBrain _cinemachineBrain;
    private void Start()
    {
        _cinemachineBrain = GetComponent<CinemachineBrain>();
        _target = Camera.main.transform;
    }
    public void ShakeCamera(float strenght, float duration)
    {
        if (!_shaking)
        {
            StartCoroutine(CrCameraShake(strenght, duration));
        }
    }

    IEnumerator CrCameraShake(float strenght, float duration)
    {
        _shaking = true;
        _cinemachineBrain.enabled = false;
        Vector3 startPos;
        float i = 0;
        while (i < duration / 2f)
        {
            i += Time.deltaTime;
            startPos = _target.position;
            _target.position = startPos + new Vector3(Random.Range(-strenght, strenght), Random.Range(-strenght, strenght), 0); ;
            yield return null;
            yield return null;
            _target.position = startPos;
        }
        _cinemachineBrain.enabled = true;
        _shaking = false;
    }
}
