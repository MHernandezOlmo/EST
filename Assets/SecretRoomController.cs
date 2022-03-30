using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomController : MonoBehaviour
{
    [SerializeField] DialogueTrigger[] _dialogs;
    [SerializeField] DialogueTrigger _findDialog;
    private int _currentDialog;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _findDialog.triggerDialogueEvent(true);
    }
    public void LoadDialog()
    {
        _dialogs[_currentDialog].triggerDialogueEvent(true);
        PlayerPrefs.SetInt("ReceiveSplitter", 1);
        _currentDialog++;
    }
}
