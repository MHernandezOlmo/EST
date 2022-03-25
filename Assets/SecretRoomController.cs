using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomController : MonoBehaviour
{
    [SerializeField] DialogueTrigger[] _dialogs;
    private int _currentDialog;

    public void LoadDialog()
    {
        _dialogs[_currentDialog].triggerDialogueEvent(true);
        _currentDialog++;
    }
}
