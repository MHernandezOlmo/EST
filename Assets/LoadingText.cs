using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _currentWait, _waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(_currentWait < _waitTime)
        {
            _text.text = "Loading";
        }
        else if (_currentWait < _waitTime * 2f)
        {
            _text.text = "Loading.";
        }
        else if (_currentWait < _waitTime * 3f)
        {
            _text.text = "Loading..";
        }
        else if (_currentWait < _waitTime * 4f)
        {
            _text.text = "Loading...";
        }
        else
        {
            _currentWait = 0f;
        }
        _currentWait += Time.deltaTime;
    }
}
