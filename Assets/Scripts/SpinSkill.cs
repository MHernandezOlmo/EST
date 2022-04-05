using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;
    public override void Interact()
    {

        
        GameProgressController.SetHasTornadoSkill(true);
        _skillText.triggerDialogueEvent(true);
        Destroy(gameObject.transform.parent.gameObject);
    }

}
