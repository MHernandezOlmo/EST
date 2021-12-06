using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaPasoAzotea : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetCurrentStartPoint(1);
        GameEvents.LoadScene.Invoke("Lomnicky_9_Sala Paso Azotea");
    }
}

