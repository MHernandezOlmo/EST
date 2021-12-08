using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSplitter : Interactable
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    public override void Interact()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        _dialogTrigger.triggerDialogueEvent();
        Destroy(transform.parent.gameObject);
    }
}
