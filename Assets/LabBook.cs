using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabBook :  Interactable
{
    void Start()
    {
        base.Start();
        if (GameProgressController.Parejas)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        FindObjectOfType<LabHelpSceneController>().BookSearch();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(transform.parent.gameObject);
    }
}
