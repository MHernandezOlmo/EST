using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementLeverAxis0 : Interactable
{
    public void Awake()
    {
        if (GameProgressController.GetOpenEinsteinBasementDoor() || !GameProgressController.EinsteinPlacedMirror)
        {
            RemoveInteractable();
        }
    }
    public override void Interact()
    {
        FindObjectOfType<SotanoEinsteinController>().MoveAxis0();

    }
}

