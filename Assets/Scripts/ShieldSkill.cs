using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : Interactable
{
    [SerializeField] DialogueTrigger _shieldDialog;
    private void Start()
    {
        base.Start();
        if (GameProgressController.SSTShieldSkill)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        _shieldDialog.triggerDialogueEvent();
        GameProgressController.SSTShieldSkill = true;
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject.transform.parent.gameObject);
    }

}
