using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTPhone : Interactable
{
    [SerializeField] DialogueTrigger _callDialogue;
    private void Start()
    {
        base.Start();
        if (GameProgressController.SSTPuzzlePairs)
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
        GameEvents.LoadScene.Invoke("SST_PicDuMidi_13_laboratory");
    }
}
