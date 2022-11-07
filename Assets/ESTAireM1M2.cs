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
            StartCoroutine(TriggerDialoGue());
            GameProgressController.ESTAireM1M2 = true;
            FindObjectOfType<MissionCanvasController>().HideMission();
            GameEvents.ShowScreenText.Invoke("Primary and secondary mirrors cooled");

        }
    }
    IEnumerator TriggerDialoGue()
    {
        yield return new WaitForSeconds(1);
        _dialogToTrigger.triggerDialogueEvent(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject);

    }
    public void SetDialog(DialogueTrigger _trigger)
    {
        _dialogToTrigger = _trigger;
    }
}