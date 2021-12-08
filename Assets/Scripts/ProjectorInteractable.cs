using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorInteractable : Interactable
{
    [SerializeField] GameObject _projectorCamera;
    [SerializeField] Sprite[] _filtros;
    [SerializeField] SpriteRenderer _filtroSR;
    [SerializeField] GameObject _projectorCanvas;
    public override void Interact()
    {
        _projectorCamera.SetActive(true);
        _projectorCanvas.SetActive(true);
        CurrentSceneManager._canMove = false;
    }

    public void Back()
    {
        _projectorCamera.SetActive(false);
        _projectorCanvas.SetActive(false);
        _filtroSR.sprite = _filtros[3];
        CurrentSceneManager._canMove = true;
    }
    
    public void ChangeFilter(int filter)
    {
        _filtroSR.sprite = _filtros[filter];
    }
}
