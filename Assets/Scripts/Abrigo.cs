using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrigo : Interactable
{
    public override void Interact()
    {
        GameProgressController.SetHasAbrigo(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtenido: Abrigo");
        Destroy(gameObject);
    }
}
