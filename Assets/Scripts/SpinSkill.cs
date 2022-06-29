using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;
    public override void Interact()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameProgressController.LomnickyTornadoSkill = true;
        _skillText.triggerDialogueEvent(true);
        Destroy(gameObject.transform.parent.gameObject);
    }

}
