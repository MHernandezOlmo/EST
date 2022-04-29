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
    bool _flattened;
    public void SetTarget(RectTransform newTarget)
    {
        _target = newTarget;
    }
    void Start()
    {
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

    }
}
