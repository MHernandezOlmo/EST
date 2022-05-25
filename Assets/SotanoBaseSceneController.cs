using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SotanoBaseSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _trigger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        if (!GameProgressController.AdviceHR)
        {
            GameProgressController.AdviceHR = true;
            _trigger.triggerDialogueEvent();
        }
    }

    void Update()
    {
        
    }
}
