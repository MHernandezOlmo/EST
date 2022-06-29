using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecuredSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _trigger;
    [SerializeField] private  bool _spectropolarimeter;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _trigger.triggerDialogueEvent(true);
    }
    public void End()
    {
        if (_spectropolarimeter)
        {
            GameProgressController.EinsteinFinished = true;
        }
        else
        {
            GameProgressController.LomnickySolved = true;
        }

        GameEvents.LoadScene.Invoke("WorldSelector");
    }
    void Update()
    {
        
    }
}
