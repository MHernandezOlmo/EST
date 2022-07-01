using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTHallSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _trigger;
    [SerializeField] GameObject _missionCanvas;

    IEnumerator Start()
    {
        if (!GameProgressController.ESTFirstAdvice)
        {
            _missionCanvas.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        if (!GameProgressController.ESTFirstAdvice)
        {
            _missionCanvas.SetActive(true);
            FindObjectOfType<MissionCanvasController>().HideMission();
            GameProgressController.ESTFirstAdvice = true;
            _trigger.triggerDialogueEvent(true);
        }
        else
        {
            FindObjectOfType<BadassAttack>().ContinuosAttack();
        }
        
    }
}
