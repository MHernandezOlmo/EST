using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilamentsBehaviour : MonoBehaviour
{
    private BoxCollider _collider;
    private bool _hunted;
    private SpriteRenderer _spriteRenderer;
    private bool _translating;
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1, 1, 1, 0);
    }

    public void Play()
    {
        _hunted = false;
        StartCoroutine(CrPlay());
    }
    public void OnMouseDown()
    {
        if (!_hunted)
        {
            _hunted = true;
            FindObjectOfType<CazaFlaresController>().NotifyFilament();
        }
    }

    IEnumerator CrPlay()
    {
        _translating = true;
        _collider.enabled = true;
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            //transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.25f);
            _spriteRenderer.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, i / 0.1f);
            yield return 0;
        }

        yield return new WaitForSeconds(5);
        _spriteRenderer.color = Color.white;
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            //transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.25f);
            _spriteRenderer.color = Color.Lerp( Color.white,new Color(1, 1, 1, 0), i / 0.1f);
            yield return 0;
        }
        _collider.enabled = false;
        _spriteRenderer.color = new Color(1, 1, 1, 0);


        _translating = false;
        //transform.localScale = Vector3.zero;
    }
    private void Update()
    {
    }
}