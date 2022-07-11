using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    RectTransform _rectTransform;
    [SerializeField] float _speed;
    [SerializeField] RectTransform _target;
    [SerializeField] Sprite _ondaPlana;
    Sprite _ondaNoPlana;
    bool _flattened;
    bool _changed;
    public void SetTarget(RectTransform newTarget)
    {
        _target = newTarget;
    }
    void Start()
    {
        _ondaNoPlana = GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = _ondaPlana;
        _rectTransform = GetComponent<RectTransform>();

    }
    public void TransformToOndaPlana()
    {
        GetComponent<Image>().sprite = _ondaPlana;
        _flattened = true;
    }
    void Update()
    {
        _rectTransform.position -= Vector3.right * _speed*Time.deltaTime;
        if (!_changed)
        {
            if(Camera.main.ScreenToViewportPoint(transform.position).x< 0.7f)
            {
                GetComponent<Image>().sprite = _ondaNoPlana;
                _changed = true;
            }
        }

    }
}
