using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementLeverAxis1 : Interactable
{
    public override void Interact()
    {
        FindObjectOfType<SotanoEinsteinController>().MoveAxis1();
    }
}

