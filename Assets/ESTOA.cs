using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTOA : Interactable
{
    [SerializeField] DialogueTrigger _dialogToTrigger;
    bool _interacted;
    private void Start()
    {
        base.Start();
        if (!GameProgressController.ESTMirrorsM3M6)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
        if (GameProgressController.ESTOA)
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
            GameEvents.ShowScreenText.Invoke("Adaptive Optics calibrated");
            _dialogToTrigger.triggerDialogueEvent(true);
            GameProgressController.ESTOA = true;
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