using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecuredSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _trigger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _trigger.triggerDialogueEvent(true);
    }
    public void End()
    {
        GameEvents.LoadScene.Invoke("WorldSelector");
    }
    void Update()
    {
        
    }
}
