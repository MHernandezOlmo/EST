using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gafas : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetHasGlasses(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtenido: Gafas");
        Destroy(gameObject);
    }
}
