using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorDirt : MonoBehaviour
{

    private Coroutine _appearRoutine;
    private RectTransform _rectTransform;
    private Image _image;
    EspejoController _espejoController;
    public bool _clean;
    public Image ImageComponent
    {
        get
        {
            return _image;
        }
    }
    void Start()
    {
        _espejoController = FindObjectOfType<EspejoController>();
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _appearRoutine =StartCoroutine(CrAppear());
        GetComponent<Button>().onClick.AddListener(() => Clean());
    }

    public void Clean()
    {
        if (_appearRoutine != null)
        {
            StopCoroutine(_appearRoutine);
        }
        StartCoroutine(CrClean());
    }

    IEnumerator CrClean()
    {
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i / 0.2f);
        }
        transform.localScale = Vector3.zero;
        _image.enabled = false;
        _clean = true;
    }
    public void CreateDirt(Vector2 pos)
    {
        if (!_image.enabled)
        {
            _clean = false;
            _image.enabled = true;
            _rectTransform.anchoredPosition = pos;
            _appearRoutine = StartCoroutine(CrAppear());
        }

    }

    IEnumerator CrAppear()
    {
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.2f);
        }
        transform.localScale = Vector3.one;
    }
}
