using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptativeOpticBinder : MonoBehaviour
{
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] GameObject _mainBinder;
    [SerializeField] GameObject[] _miniBinder;
    public void WrongAnswer()
    {
        print("NO!");
    }

    public void CorrectAnswer()
    {
        GameEvents.LoadScene.Invoke("ParejasInProgress");
    }
    public void OpenBinderCanvas()
    {
        _mainCanvas.SetActive(true);
    }
    public void OpenBinder(int binder)
    {
        _mainBinder.SetActive(false);
        for(int i = 0; i<_miniBinder.Length; i++)
        {
            _miniBinder[i].SetActive(false);
        }
        _miniBinder[binder].SetActive(true);
    }

    public void CloseBinder()
    {
        for (int i = 0; i < _miniBinder.Length; i++)
        {
            _miniBinder[i].SetActive(false);
        }
        _mainBinder.SetActive(true);
    }

    public void CloseEverything()
    {
        _mainCanvas.SetActive(false);
    }
}
