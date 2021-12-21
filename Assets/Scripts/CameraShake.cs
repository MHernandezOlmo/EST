using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool _shaking;
    private CinemachineBrain _cinemachineBrain;

    public void ShakeCamera(float strenght, float duration)
    {
        if (_cinemachineBrain == null)
        {
            _cinemachineBrain = GetComponent<CinemachineBrain>();
        }
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
            startPos = transform.position;
            transform.position = startPos + new Vector3(Random.Range(-strenght, strenght), Random.Range(-strenght, strenght), 0); ;
            yield return null;
            yield return null;
            transform.position = startPos;
        }
        _cinemachineBrain.enabled = true;
        _shaking = false;
    }
}
