using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject _cinematicCanvas;
    private void Start()
    {
        Hide();
    }
    public void Show()
    {
        _cinematicCanvas.SetActive(true);
    }

    public void Hide()
    {
        _cinematicCanvas.SetActive(false);
    }
}
