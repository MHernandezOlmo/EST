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
        yield return null;
        if (GameProgressController.IsChoosePhenomenomSolved())
        {
            _dialogueTrigger.triggerDialogueEvent(true);
            GameEvents.ShowScreenText.Invoke("Regresa al teleférico");
        }
    }

    void Update()
    {
       
    }
}
