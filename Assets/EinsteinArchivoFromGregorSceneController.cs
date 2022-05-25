using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinArchivoFromGregorSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _trigger;

    IEnumerator Start()
    {
        if (!GameProgressController.TestedHR)
        {
            yield return new WaitForSeconds(1f);
            _trigger.triggerDialogueEvent(true);
        }
    }

    void Update()
    {
        
    }
}
