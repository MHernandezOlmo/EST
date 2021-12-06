using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTSalaMaquinasSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    void Start()
    {
        if (!GameProgressController.GetSSTCollaborativeAlertShown())
        {
            if(GameProgressController.GetIsSSTColdSystemFixed() && GameProgressController.GetIsVacuumSolved())
            {
                StartCoroutine(CrPlayDialog());
                GameProgressController.SetSSTCollaborativeAlertShown(true);
            }
        }
    }
    IEnumerator CrPlayDialog()
    {
        yield return new WaitForSeconds(1f);
        _dialogTrigger.triggerDialogueEvent();
    }
}
