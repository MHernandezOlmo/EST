using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaSalaSecreta : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetCurrentStartPoint(0);
        GameEvents.LoadScene.Invoke("Lomnicky_12_Sala Secreta");
    }
}
