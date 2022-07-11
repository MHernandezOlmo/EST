using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRoto : Interactable
{
    [SerializeField]
    DialogueTrigger _dialogue;
    bool _hasInteracted;
    [SerializeField] DialogueTrigger _filterQuest;

    
    public override void Interact()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject);
        _dialogue.triggerDialogueEvent(true);

    }
    private void Start()
    {
        base.Start();
        if (GameProgressController.PicDuMidiPuzzleCoronagraph || GameProgressController.PicDuMidiNeedContactUV)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }


}
