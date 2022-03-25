using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;
    public override void Interact()
    {
        GameProgressController.SetHasDash(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("Alert/FindCableCar"));
        GameProgressController.SetHasTornadoSkill(true);
        _skillText.triggerDialogueEvent(true);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
