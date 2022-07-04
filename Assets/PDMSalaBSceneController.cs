using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDMSalaBSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _asociationSolvedAdvice;
    IEnumerator Start()
    {
        yield return null;
        if (GameProgressController.PicDuMidiPuzzleAssociation)
        {
            if (!GameProgressController.PicDuMidiAssociationSolvedAdvice)
            {
                GameProgressController.PicDuMidiAssociationSolvedAdvice = true;
                _asociationSolvedAdvice.triggerDialogueEvent(true);
            }
        }
    }

    void Update()
    {
        
    }
}
