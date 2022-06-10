using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTHallSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _trigger;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        if (!GameProgressController.ESTFirstAdvice)
        {
            GameProgressController.ESTFirstAdvice = true;
            _trigger.triggerDialogueEvent(true);
        }
        else
        {
            FindObjectOfType<BadassAttack>().ContinuosAttack();
        }
        
    }

    void Update()
    {
        
    }
}
