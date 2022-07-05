using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabHelpSceneController : MonoBehaviour
{
    int counter;
    [SerializeField] List<DialogueTrigger> _dialogs;

    IEnumerator Start()
    {
        if (GameProgressController.SSTPuzzlePairs)
        {
            yield return new WaitForSeconds(1f);
            _dialogs[3].triggerDialogueEvent(true);
        }
    }
    public void Back()
    {
        GameEvents.LoadScene.Invoke("SST_4_sala_observacion");
    }
    public void BookSearch()
    {
        if (counter == 3)
        {
            GameEvents.LoadScene.Invoke("SSTPuzzlePairs");
        }
        else
        {
            _dialogs[counter].triggerDialogueEvent();
            counter++;
        }
    }
}
