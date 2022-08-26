using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorInteractableAttempt : Interactable
{
    public void Awake()
    {
        if (GameProgressController.GetOpenEinsteinBasementDoor())
        {
            RemoveInteractable();
        }
    }

    public override void Interact()
    {
        FindObjectOfType<SotanoEinsteinController>().Advice();
        RemoveInteractable();

    }
}

