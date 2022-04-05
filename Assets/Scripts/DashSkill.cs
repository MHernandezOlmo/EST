using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;

    public void Awake()
    {
        if (GameProgressController.HasDash())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public override void Interact()
    {
        GameProgressController.SetHasDash(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        _skillText.triggerDialogueEvent(true);
        Destroy(gameObject.transform.parent.gameObject);
    }

}
