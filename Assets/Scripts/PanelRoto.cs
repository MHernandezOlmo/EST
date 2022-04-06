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
        if (GameProgressController.IsPanelFixed())
        {

        }
        else
        {
            if (!_hasInteracted)
            {
                _hasInteracted = true;
                _dialogue.triggerDialogueEvent(true);
            }
        }
    }
    private void Start()
    {
        base.Start();
        //if (PlayerPrefs.GetInt("ComingFromPDMD") == 1)
        //{
        //    PlayerPrefs.SetInt("ComingFromPDMD", 0);
        //    StartCoroutine(WaitForDialog());
        //}
    }
    IEnumerator WaitForDialog()
    {
        yield return new WaitForSeconds(1f);
        _filterQuest.triggerDialogueEvent();
    }


}
