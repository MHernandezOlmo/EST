using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCallback : MonoBehaviour
{
    [SerializeField] DialogueTrigger _lastDialog;
    public void TriggerLastDialog()
    {
        _lastDialog.triggerDialogueEvent(true);
    }
}
