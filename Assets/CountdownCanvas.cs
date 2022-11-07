using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownCanvas : MonoBehaviour
{
    float _totalTime;
    float _elapsedTime;
    TextMeshProUGUI _text;
    private static CountdownCanvas c;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _totalTime = 120;
        DontDestroyOnLoad(transform.parent.gameObject);
        if (c== null)
        {
            c = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        int remainingTime = (int)(_totalTime - _elapsedTime);
        _text.text = remainingTime.ToString();
        if(remainingTime<= 0)
        {
            GameEvents.LoadScene.Invoke("Gregor_11_almacen");
            Destroy(gameObject);
        }
    }
    public void Restart()
    {
        GameEvents.LoadScene.Invoke("Gregor_11_almacen");
        Destroy(gameObject);
    }
}
