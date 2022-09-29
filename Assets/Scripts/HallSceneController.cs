using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _firstSSTEntryDialog;
    [SerializeField] private GameObject _sceneChanger;
    [SerializeField] private GameObject _lamparaOff;
    [SerializeField] private GameObject _lamparaOn;
    void Start()
    {
        if (!GameProgressController.SSTHallAdvice)
        {
            StartCoroutine(PlayFirstSSTEntryDialog());
        }   
        if(!GameProgressController.SSTColdSystemFixed || !GameProgressController.SSTVacuumSystemFixed)
        {
            _sceneChanger.gameObject.SetActive(false);
            _lamparaOff.gameObject.SetActive(true);
            _lamparaOn.gameObject.SetActive(false);
        }
        else
        {
            _lamparaOff.gameObject.SetActive(false);
            _lamparaOn.gameObject.SetActive(true);
        }
    }

    IEnumerator PlayFirstSSTEntryDialog()
    {
        GameEvents.ClearMissionText.Invoke();
        yield return new WaitForSeconds(1);
        _firstSSTEntryDialog.triggerDialogueEvent();
        GameProgressController.SSTHallAdvice = true;
    }
}
