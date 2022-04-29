using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPump : Interactable
{
    private void Start()
    {
        base.Start();
        if (GameProgressController.GetIsVacuumSolved())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        GameEvents.LoadScene.Invoke("Bomba");
    }
}
