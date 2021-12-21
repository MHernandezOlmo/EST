using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VignettingController : MonoBehaviour
{
    [SerializeField] private Color _defColor, _hitColor;
    private Image _vignette;
    private Coroutine _hitCr;

    private void Start()
    {
        _vignette = GetComponent<Image>();
    }

    public void ReceiveHit()
    {
        if(_hitCr != null)
        {
            StopCoroutine(_hitCr);
        }
        StartCoroutine(ReceiveHitCr());
    }

    IEnumerator ReceiveHitCr()
    {
        float duration = 0.25f;
        float currentTime = 0f;
        Color initColor = _vignette.color;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            _vignette.color = Color.Lerp(initColor, _hitColor, currentTime/duration);
            yield return null;
        }
        _vignette.color = _hitColor;

        yield return new WaitForSeconds(0.1f);
        currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            _vignette.color = Color.Lerp(_hitColor, _defColor, currentTime / duration);
            yield return null;
        }
        _vignette.color = _defColor;
    }
}
