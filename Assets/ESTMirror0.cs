using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTMirror0 : Interactable
{
    bool _interacted;
    private void Start()
    {
        base.Start();
        if (!GameProgressController.ESTAireM1M2)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
        if (GameProgressController.ESTMirror0)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        if (!_interacted)
        {
            FindObjectOfType<ESTRefrigeranteM3aM6SceneController>().SetMirror(0);
            GameProgressController.ESTMirror0 = true;
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }

    }
}