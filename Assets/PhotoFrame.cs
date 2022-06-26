using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoFrame : MonoBehaviour
{
    float _elapsedTime;
    [SerializeField] AnimationCurve _animationCurve;
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] RectTransform _myRectTransform;
    [SerializeField] Color _color;
    [SerializeField] Image _image;
    private Coroutine _crPhoto;
    bool _active;
    bool _canCheck;
    int _moveCounter;
    bool _canTakePhoto;
    [SerializeField] Image _photoProgress;
    SunShake _sunShake;
    void Start()
    {
        _sunShake = GetComponentInChildren<SunShake>();
        _active = true;
        _canCheck = true;
        StartCoroutine(CrMove());

    }
    public void CheckPhoto()
    {
        if (_canCheck && _crPhoto == null)
        {
            _crPhoto = StartCoroutine(TakePhoto());
        }
    }
    IEnumerator TakePhoto()
    {
        for(float i = 0; i< 1f; i += Time.deltaTime)
        {
            _photoProgress.fillAmount = i;
            yield return null;
        }
        _photoProgress.fillAmount = 0;
        _canCheck = false;
        if (_myRectTransform.anchoredPosition.magnitude < 20f)
        {
            _image.color = Color.green;
            FindObjectOfType<CoronografoController>().Next();
            StartCoroutine(Recover());
        }
        else
        {
            _image.color = Color.red;
            FindObjectOfType<CoronografoController>().LoseLife();
            StartCoroutine(Recover());
        }
        _crPhoto = null;
    }
    IEnumerator Recover()
    {
        _active = false;
        yield return new WaitForSeconds(2f);
        _active = true;
        _canCheck = true;
        _image.color = _color;

    }
    IEnumerator CrMove()
    {
        _sunShake.SetEstabilized(false);
        _canTakePhoto = false;
        _moveCounter++;
        Vector2 _targetPosition = new Vector2(Random.Range(120, 200), Random.Range(120, 200));
        bool stop = false; ;
        if (_moveCounter % 5 == 0)
        {
            stop = true;
            _targetPosition = new Vector2(0,0);
        }
        _targetPosition.x = Random.value > 0.5f ? _targetPosition.x *-1: _targetPosition.x;
        _targetPosition.y = Random.value > 0.5f ? _targetPosition.y * -1 : _targetPosition.y;
        Vector2 _currentPosition = _rectTransform.anchoredPosition;
        for(float i = 0; i< 1f; i += Time.deltaTime)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(_currentPosition, _targetPosition,_animationCurve.Evaluate(i/1f));
            yield return null;
        }
        if (stop)
        {
            if (Random.value > 0.5f)
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                _sunShake.SetEstabilized(true);
                _canTakePhoto = true;
                yield return new WaitForSeconds(5f);
            }
        }
        StartCoroutine(CrMove());
    }
    void Update()
    {
        _myRectTransform.anchoredPosition = Vector2.Lerp(_myRectTransform.anchoredPosition, _rectTransform.anchoredPosition, Time.deltaTime);
        //if (_active)
        //{
        //    _elapsedTime += Time.deltaTime;
        //    _elapsedTime %= 2;
        //    _rectTransform.localScale = Vector3.one * _animationCurve.Evaluate(_elapsedTime / 2f);
        //    if (_rectTransform.localScale.x > 0.9f)
        //    {
        //        _image.color = _color;
        //    }
        //    else
        //    {
        //        _image.color = Color.white;
        //    }
        //}
    }
}
