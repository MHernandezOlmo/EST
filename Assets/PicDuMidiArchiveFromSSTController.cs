using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicDuMidiArchiveFromSSTController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _solvedParejasDialog;
    void Start()
    {
        if (GameProgressController.GetSolvedPuzzleParejas())
        {
            StartCoroutine(CrPlayDialog());
        }
    }

    IEnumerator CrPlayDialog()
    {
        yield return new WaitForSeconds(1f);
        _solvedParejasDialog.triggerDialogueEvent();
    }

    public void ReturnToSST()
    {
        GameProgressController.SetCurrentStartPoint(1);
        GameProgressController.SetSSTCollaborativeSceneSolved(true);
        GameEvents.LoadScene.Invoke("SST_4_sala_observacion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
