﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;
    public override void Interact()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtenido: Habilidad Cañón Solar");
        _skillText.triggerDialogueEvent(true);
        GameProgressController.SetHasSolarCanon(true);
        Destroy(gameObject.transform.parent.gameObject);
    }


}
