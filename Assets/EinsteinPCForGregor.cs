using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinPCForGregor : Interactable
{
    public override void Interact()
    {
        GameEvents.LoadScene.Invoke("TestHR");
    }
}
