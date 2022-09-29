using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SotanoBaseSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _trigger;
    [SerializeField] private GameObject _doorTrigger, _heatCanvas;
    IEnumerator Start()
    {
        if (!GameProgressController.AdviceHR)
        {
            _heatCanvas.SetActive(false);
            GameEvents.ClearMissionText.Invoke();
        }
        if (FindObjectOfType<CountdownCanvas>() != null)
        {
            _doorTrigger.SetActive(false);
        }
        yield return new WaitForSeconds(1);
        if (!GameProgressController.AdviceHR)
        {
            GameProgressController.AdviceHR = true;
            _trigger.triggerDialogueEvent();
        }
    }
}
