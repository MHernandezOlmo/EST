using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCArchivoInteractableFromPDMD : Interactable
{
    [SerializeField]
    DialogueTrigger _dialogToTrigger;
    bool _interacted;
    public override void Interact()
    {
        if (!_interacted)
        {
            _interacted = true;
            GameEvents.LoadScene.Invoke("PicDuMidiPuzzleCoronagraph");
        }

    }

}
