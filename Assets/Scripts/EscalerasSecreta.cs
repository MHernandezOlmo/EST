using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasSecreta : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetCurrentStartPoint(3);
        GameEvents.LoadScene.Invoke("Lomnicky_10_Azotea");
    }
}

