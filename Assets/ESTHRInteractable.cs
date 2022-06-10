using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTHRInteractable : Interactable
{
    [SerializeField] DialogueTrigger _dialogToTrigger;
    bool _interacted;
    private void Start()
    {
        base.Start();
        
        if (!GameProgressController.ESTOA)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
        if (GameProgressController.ESTHR)
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
            _dialogToTrigger.triggerDialogueEvent(true);
            GameProgressController.ESTHR = true;
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
}