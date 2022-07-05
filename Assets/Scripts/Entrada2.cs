using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada2 : Interactable
{
    [SerializeField] DialogueTrigger _lock;
    [SerializeField] DialogueTrigger _fight;

    bool _already;
    bool canUse;
    public override void Interact()
    {
        if (!canUse)
        {
            if (!_already)
            {
                _already = true;
                _lock.triggerDialogueEvent(true);
            }
        }
        else
        {
            GameProgressController.SetCurrentStartPoint(0);
            GameEvents.LoadScene.Invoke("PicDuMidi_7_sotano_acceso_central");
        }
        
        //GameProgressController.SetCurrentStartPoint(0);
        //GameEvents.LoadScene.Invoke("PicDuMidi_7_sotano_acceso_central");
    }
    private void Start()
    {
        base.Start();
        canUse = GameProgressController.PicDuMidiUncoveredJeanRoch && GameProgressController.TelescopeReady && GameProgressController.PicDuMidiPuzzleCoronagraph;
        
        if (GameProgressController.PicDuMidiPuzzleAssociation)
        {
            StartCoroutine(CrFight());
        }
    }

    IEnumerator CrFight()
    {
        yield return new WaitForSeconds(1f);
        _fight.triggerDialogueEvent(true);
    }

}
