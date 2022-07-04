using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoCoronografo : MonoBehaviour
{
    [SerializeField] DialogueTrigger _trigger;

    void Update()
    {
        if (GameProgressController.PicDuMidiCoronalEjectionAdvice)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _trigger.triggerDialogueEvent();
        StartCoroutine(WaitForExploration());
    }

    IEnumerator WaitForExploration()
    {
        if(CurrentSceneManager._state!= GameStates.Exploration)
        {
            yield return null;
        }
        GameProgressController.PicDuMidiCoronalEjectionAdvice = true;
    }
}
