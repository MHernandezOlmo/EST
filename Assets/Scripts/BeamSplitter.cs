using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSplitter : Interactable
{
    public override void Interact()
    {
        FindObjectOfType<SecretRoomController>().LoadDialog();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(transform.parent.gameObject);
    }
}
