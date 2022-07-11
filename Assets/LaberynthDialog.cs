using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaberynthDialog : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _trigger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        if (!GameProgressController.PicDuMidiLaberynthDialog)
        {
            _trigger.triggerDialogueEvent(true);
            GameProgressController.PicDuMidiLaberynthDialog = true;
        }
    }

}
