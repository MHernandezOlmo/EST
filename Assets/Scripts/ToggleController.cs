using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ToggleController : MonoBehaviour
{
    bool _state;
    [SerializeField]
    Image _bar;
    [SerializeField]
    Sprite _barOn = default;
    [SerializeField]
    Sprite _barOff;
    [SerializeField]
    Image _handle  =default;
    [SerializeField]
    Sprite _handleOn;
    [SerializeField]
    Sprite _handleOff = default;
    [SerializeField]
    UnityEvent functionToCallOnEnable;
    [SerializeField]
    UnityEvent functionToCallOnDisable;
    public void OnToggleChange()
    {
        _state = !_state;
        if (_state)
        {
            RefreshGraphic();
            functionToCallOnEnable.Invoke();
        }
        else
        {
            RefreshGraphic();
            functionToCallOnDisable.Invoke();
        }
    }

    public void RefreshGraphic()
    {
        if (_state)
        {
            _bar.sprite = _barOn;
            _bar.overrideSprite = _barOn;
            _handle.sprite = _handleOn;
            _handle.overrideSprite = _handleOn;
            _handle.rectTransform.anchoredPosition = new Vector3(45, -7, 0);
        }
        else
        {
            _bar.sprite = _barOff;
            _bar.overrideSprite = _barOff;
            _handle.sprite = _handleOff;
            _handle.overrideSprite = _handleOff;
            _handle.rectTransform.anchoredPosition = new Vector3(-45, -7, 0);
        }
    }
    public void SetState(bool newState)
    {
        _state = newState;
        RefreshGraphic();
    }
}
