using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspectropolarimetroInteractable : Interactable
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    public override void Interact()
    {
        GameEvents.ClearMissionText.Invoke();
        FindObjectOfType<SalaEspectropolarimetroSceneController>().UseBeamSplitter();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        _dialogTrigger.triggerDialogueEvent();
        Destroy(transform.parent.gameObject);
    }
}
