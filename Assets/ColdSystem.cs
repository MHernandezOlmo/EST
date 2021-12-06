using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdSystem : Interactable
{
    private void Start()
    {
        base.Start();
        if (GameProgressController.GetIsSSTColdSystemFixed())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        GameEvents.LoadScene.Invoke("Puzzle Vacio torre  In Progress");
    }
}
