using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasCupula : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetCurrentStartPoint(2);
        GameEvents.LoadScene.Invoke("Lomnicky_8_Sala Principal");
    }
}
