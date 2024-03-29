﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTOpenDome : Interactable
{
    [SerializeField] DialogueTrigger _dialogToTrigger;
    bool _interacted;
    private void Start()
    {
        base.Start();
        if (!GameProgressController.ESTGenerador)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
        if (GameProgressController.ESTDomeOpen)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        if (!_interacted)
        {
            _interacted = true;
            GameEvents.LoadScene.Invoke("EST_CupulaBis");
            //_dialogToTrigger.triggerDialogueEvent(true);
        }

    }
    public void SetDialog(DialogueTrigger _trigger)
    {
        _dialogToTrigger = _trigger;
    }
}
