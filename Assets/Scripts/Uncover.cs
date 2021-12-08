using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncover : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetUncovered(true);
        GameProgressController.SetCurrentStartPoint(1);
        GameEvents.LoadScene.Invoke("PicDuMidi_8_exterior_jeanrock");
    }
}
