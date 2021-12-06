using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTPhone : Interactable
{
    [SerializeField] DialogueTrigger _callDialogue;
    private void Start()
    {
        base.Start();
        if (!GameProgressController.GetSSTCollaborativeAlertShown()|| GameProgressController.GetSSTCollaborativeSceneSolved())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        _callDialogue.triggerDialogueEvent();
    }

    public void LoadNextScene()
    {
        GameEvents.LoadScene.Invoke("PicDuMidi_9_paneles_d From SST");
    }
}
