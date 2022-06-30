using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservacionSSTSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _adaptativeOpticPiezesAlertDialog;
    [SerializeField] DialogueTrigger _youHaveEverything;
    void Start()
    {
        if (GameProgressController.Parejas && ! GameProgressController.GetAdaptativeOpticsPiezesAlertShown())
        {
            StartCoroutine(CrPlayDialog());
        }
        if (GameProgressController.GetHasAO())
        {
            if (PlayerPrefs.GetInt("HasReadedDialog", 0) == 0)
            {
                StartCoroutine(CrPlayDialog2());
                PlayerPrefs.SetInt("HasReadedDialog", 1);
            }
        }
    }
    IEnumerator CrPlayDialog()
    {
        yield return new WaitForSeconds(1);
        _adaptativeOpticPiezesAlertDialog.triggerDialogueEvent(true);
        GameProgressController.SetAdaptativeOpticsPiezesAlertShown(true);
    }
    IEnumerator CrPlayDialog2()
    {
        yield return new WaitForSeconds(1);
        _youHaveEverything.triggerDialogueEvent(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
