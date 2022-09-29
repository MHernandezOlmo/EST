using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTSalaMaquinasSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    void Awake()
    {

        if (PlayerPrefs.GetInt("GlycolAmount")==70f && !GameProgressController.SSTColdSystemFixed)
        {
            GameProgressController.SSTColdSystemFixed =true;
        }

        if (!GameProgressController.SSTColaborativeAlert)
        {
            if(GameProgressController.SSTColdSystemFixed && GameProgressController.SSTVacuumSystemFixed)
            {
                StartCoroutine(CrPlayDialog());
                GameProgressController.SSTColaborativeAlert = true;
            }
        }
    }

    IEnumerator CrPlayDialog()
    {
        GameEvents.ClearMissionText.Invoke();
        yield return new WaitForSeconds(1f);
        _dialogTrigger.triggerDialogueEvent();
    }
    
}
