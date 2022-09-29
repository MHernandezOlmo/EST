using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGregorInteractable : Interactable
{
    DialogueTrigger _dialogToTrigger;
    bool _interacted;
    public override void Interact()
    {
        if (!_interacted)
        {
            GameEvents.ClearMissionText.Invoke();
            _interacted = true;
            _dialogToTrigger.triggerDialogueEvent(true);
        }

    }
    public void SetDialog(DialogueTrigger _trigger)
    {
        _dialogToTrigger = _trigger;
    }
}
