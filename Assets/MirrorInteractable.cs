using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInteractable : Interactable
{
    
    public override void Interact()
    {
        FindObjectOfType<EinsteinDomeSceneController>().PlaceMirror();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(transform.parent.gameObject);
    }
}
