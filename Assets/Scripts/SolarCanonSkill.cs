using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCanonSkill : Interactable
{
    [SerializeField] DialogueTrigger _skillText;
    public override void Interact()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);   
        _skillText.triggerDialogueEvent(true);
        GameProgressController.EinsteinSolarCanonSkill = true;
        Destroy(gameObject.transform.parent.gameObject);
    }

    void Awake()
    {
        if (GameProgressController.EinsteinSolarCanonSkill)
        {
            RemoveInteractable();
        }
    }


}
