using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementLeverAxis0 : Interactable
{
    public override void Interact()
    {
        FindObjectOfType<SotanoEinsteinController>().MoveAxis0();

    }
}

