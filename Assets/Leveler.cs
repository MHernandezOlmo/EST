using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Leveler : MonoBehaviour
{
    [SerializeField] RectTransform _circle;
    [SerializeField] AnimationCurve _animationCurve;
    float _elapsedTime;
    [SerializeField] float _time;
    bool _down;
    bool _active;
    [SerializeField] Image _back;
    [SerializeField] Color _color;
    [SerializeField] float _targetValue;
    float _height;
    void Start()
    {
        _height = GetComponent<RectTransform>().sizeDelta.y;
    }
    public void Check()
    {
        if (_active)
        {
            float value = Mathf.Abs(((_circle.anchoredPosition.y + (_height/2f)) / _height) - _targetValue);
            if (value < 0.09f)
            {
                _active = false;
                _back.color = Color.green;
                FindObjectOfType<CoronografoController>().Next();
            }
            else
            {
                _active = false;
                StartCoroutine(ReActivate());
            }
        }
    }
    IEnumerator ReActivate()
    {
        FindObjectOfType<CoronografoController>().LoseLife();
        _back.color = Color.red;
        yield return new WaitForSeconds(1f);
        _back.color = _color;
        _active = true;
    }

    public void Activate()
    {
        _active = true;
        _back.color = _color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Check();
        }
        if (_active)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _time)
            {
                _elapsedTime = 0f;
                _down = !_down;
            }
            float lerpValue = 0f;
            if (_down)
            {
                lerpValue = _elapsedTime;
            }
            else
            {
                lerpValue = _time - _elapsedTime;
            }
            _circle.anchoredPosition = Vector3.Lerp(Vector3.up * (_height/2f), Vector3.up * (-_height / 2f), _animationCurve.Evaluate(lerpValue / _time));
        }
    }
}
