using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasSotano : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetCurrentStartPoint(2);
        GameEvents.LoadScene.Invoke("PicDuMidi_5_patio");
    }
}