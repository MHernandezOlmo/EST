using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTAireM1M2 : Interactable
{
    [SerializeField] DialogueTrigger _dialogToTrigger;
    bool _interacted;
    private void Start()
    {
        base.Start();
        if (!GameProgressController.ESTDomeOpen)
        {

            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
        if (GameProgressController.ESTAireM1M2)
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
            GameProgressController.ESTAireM1M2 = true;
            FindObjectOfType<MissionCanvasController>().HideMission();
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