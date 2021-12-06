using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallSceneController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _firstSSTEntryDialog;
    void Start()
    {
        if (!GameProgressController.GetFistSSTEntry())
        {
            StartCoroutine(PlayFirstSSTEntryDialog());
        }   
    }

    IEnumerator PlayFirstSSTEntryDialog()
    {
        yield return new WaitForSeconds(1);
        _firstSSTEntryDialog.triggerDialogueEvent();
        GameProgressController.SetFirstSSTEntry(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
