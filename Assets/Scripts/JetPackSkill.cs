using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;
    public override void Interact()
    {
        GameProgressController.Jetpack =true;
        _skillText.triggerDialogueEvent(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject.transform.parent.gameObject);
    }

}
