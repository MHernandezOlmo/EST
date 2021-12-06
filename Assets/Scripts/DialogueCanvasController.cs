using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject _dialogCanvas;
    private void Start()
    {
        Hide();
    }
    public void Show()
    {
        _dialogCanvas.SetActive(true);
    }

    public void Hide()
    {
        _dialogCanvas.SetActive(false);
    }
    
}
