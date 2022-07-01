using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTHRyAbrirCupulaSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialog3;
    [SerializeField] private DialogueTrigger _mirrorAdvice;

    IEnumerator Start()
    {
        if (GameProgressController.ESTDomeOpen)
        {
            if (!GameProgressController.ESTSecondAdvice)
            {
                yield return null;
                FindObjectOfType<MissionCanvasController>().HideMission();
            }
        }
        yield return new WaitForSeconds(1f);
        if (GameProgressController.ESTDomeOpen)
        {
            if (!GameProgressController.ESTSecondAdvice)
            {
                FindObjectOfType<MissionCanvasController>().HideMission();
                GameProgressController.ESTSecondAdvice = true;
                _dialog3.triggerDialogueEvent(true);
            }
        }
        if(GameProgressController.Mirror && !GameProgressController.MirrorAdvice)
        {
            GameProgressController.MirrorAdvice = true;
            _mirrorAdvice.triggerDialogueEvent(true);
        }
    }

    public void Load1stPersonPuzzle()
    {
        GameEvents.LoadScene.Invoke("Espejo");
    }
}
