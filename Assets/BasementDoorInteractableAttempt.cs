using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorInteractableAttempt : Interactable
{
    public void Awake()
    {
        if (GameProgressController.GetOpenEinsteinBasementDoor() || GameProgressController.EinsteinBasementDialog)
        {
            RemoveInteractable();
        }
    }

    public override void Interact()
    {
        GameEvents.ClearMissionText.Invoke();
        FindObjectOfType<SotanoEinsteinController>().Advice();
        GameProgressController.EinsteinBasementDialog = true;
        RemoveInteractable();
    }
}

