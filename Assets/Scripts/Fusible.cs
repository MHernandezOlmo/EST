using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusible : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetHasFuse(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("Alert/GetFuse"));
        Destroy(gameObject);
    }


}
