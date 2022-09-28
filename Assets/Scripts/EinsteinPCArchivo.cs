using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinPCArchivo : Interactable
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    public override void Interact()
    {
        GameEvents.ClearMissionText.Invoke();
        _dialogTrigger.triggerDialogueEvent();
    }
}
