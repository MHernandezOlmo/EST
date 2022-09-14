using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _dialogueTrigger;
    bool _havePieces;
    IEnumerator Start()
    {
        _havePieces = false;
        yield return new WaitForSeconds(1f);
        if (GameProgressController.LomnickyPuzzleLayers)
        {
            _dialogueTrigger.triggerDialogueEvent(true);
            
        }
    }

    public void ShowAdvice()
    {
        GameEvents.ShowScreenText.Invoke("Go back to the cableway");
        GameEvents.MissionText.Invoke("Go back to the cableway");
    }
}
