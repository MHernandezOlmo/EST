using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Interactable
{

    public override void Interact()
    {
        GameProgressController.SetHasDash(true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtenido: Habilidad Dash");
        Destroy(gameObject.transform.parent.gameObject);
    }
}
