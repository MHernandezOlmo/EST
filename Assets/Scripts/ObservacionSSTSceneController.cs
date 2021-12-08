using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservacionSSTSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _adaptativeOpticPiezesAlertDialog;
    void Start()
    {
        if (GameProgressController.GetSSTCollaborativeSceneSolved() && ! GameProgressController.GetAdaptativeOpticsPiezesAlertShown())
        {
            StartCoroutine(CrPlayDialog());
        }
    }
    IEnumerator CrPlayDialog()
    {
        yield return new WaitForSeconds(1);
        _adaptativeOpticPiezesAlertDialog.triggerDialogueEvent(true);
        GameProgressController.SetAdaptativeOpticsPiezesAlertShown(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
