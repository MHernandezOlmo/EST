using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactUVInteractable : Interactable
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    private void Awake()
    {
        if (!GameProgressController.NeedContactUV)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        _dialogTrigger.triggerDialogueEvent();
    }
}
