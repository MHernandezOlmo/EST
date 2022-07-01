using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGeneradorInteractable : Interactable
{
    [SerializeField] DialogueTrigger _dialogToTrigger;
    bool _interacted;
    private void Start()
    {
        base.Start();
        if (GameProgressController.ESTGenerador)
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
            GameProgressController.ESTGenerador = true;
            _dialogToTrigger.triggerDialogueEvent(true);
            FindObjectOfType<DarknessController>().TurnOnLight();
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }

    }
    public void SetDialog(DialogueTrigger _trigger)
    {
        _dialogToTrigger = _trigger;
    }

    public void LoadOtherScene()
    {

    }
}
