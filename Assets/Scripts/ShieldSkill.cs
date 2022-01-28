using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : Interactable
{
    [SerializeField] DialogueTrigger _shieldDialog;
    private void Start()
    {
        base.Start();
        if (GameProgressController.GetHasShield())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        _shieldDialog.triggerDialogueEvent();
        GameProgressController.SetHasShield(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtained: Shield Skill");
        Destroy(gameObject.transform.parent.gameObject);
    }
}
