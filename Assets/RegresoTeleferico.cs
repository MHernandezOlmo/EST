using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegresoTeleferico : Interactable
{
    public override void Interact()
    {
        if (GameProgressController.IsChoosePhenomenomSolved())
        {
            GameEvents.LoadScene.Invoke("MainMenu");
        }
    }
}
