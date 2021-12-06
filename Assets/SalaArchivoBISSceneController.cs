using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaArchivoBISSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _dialog;
    void Start()
    {
    }
    

    IEnumerator WaitForDialog()
    {
        yield return new WaitForSeconds(1f);
        _dialog.triggerDialogueEvent(true);
    }
    
    public void ReturnToEinstein()
    {
        GameEvents.LoadScene.Invoke("Einstein_3_planta_1_sala_archivo");
        GameProgressController.SetHasPrismEinstein(true);
        GameProgressController.SetCurrentStartPoint(1);
    }
}
