using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorInteractable : Interactable
{
    [SerializeField] GameObject _projectorCamera;
    [SerializeField] Sprite[] _filtros;
    [SerializeField] SpriteRenderer _filtroSR;
    [SerializeField] GameObject _projectorCanvas;
    [SerializeField] DialogueTrigger _dialog;
    [SerializeField] GameObject _info;

    private void Awake()
    {
    }

    public override void Interact()
    {
        if (GameProgressController.HasAllPicDuMidiFilters())
        {
            _projectorCamera.SetActive(true);
            _projectorCanvas.SetActive(true);
            _info.SetActive(false);
            CurrentSceneManager._canMove = false;
        }
        else
        {
            _dialog.triggerDialogueEvent(true);
        }
    }

    public void Back()
    {
        _projectorCamera.SetActive(false);
        _projectorCanvas.SetActive(false);
        _info.SetActive(true);
        _filtroSR.sprite = _filtros[5];
        CurrentSceneManager._canMove = true;
    }
    
    public void ChangeFilter(int filter)
    {
        _filtroSR.sprite = _filtros[filter];
    }
}
