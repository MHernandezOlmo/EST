using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrigo : Interactable
{
    public void Start()
    {
        if (GameProgressController.GetHasAbrigo())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        GameProgressController.SetHasAbrigo(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtained: Coat");
        Destroy(gameObject);
    }
}
