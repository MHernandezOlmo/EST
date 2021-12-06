using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaProyector : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    [SerializeField] Transform _lens;
    [SerializeField] Transform[] _corners;
    [SerializeField] LineRenderer[] _cornersLR;
    [SerializeField] Material _mat;
    [SerializeField] LineRenderer[] _sideLR;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < _corners.Length; i++)
        {
            _cornersLR[i].SetPosition(0, _lens.position);
            _cornersLR[i].SetPosition(1, _corners[i].position);
        }
    }
    void Update()
    {
        _spriteRenderer.color = new Color(1, 1, 1, Random.Range(0.4f, 0.8f));
        _mat.color = new Color(1, 1, 1, Random.Range(0.1f, 0.8f));

        for(int i = 0; i< _sideLR.Length; i++)
        {
            int nextCorner = (i + 1) % _corners.Length;
            _sideLR[i].SetPosition(1, Vector3.Lerp(_corners[i].position, _corners[nextCorner].position, Random.Range(0f, 1f)));
        }
    }
}
