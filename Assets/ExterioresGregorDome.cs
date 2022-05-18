using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExterioresGregorDome : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _trigger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _trigger.triggerDialogueEvent(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
