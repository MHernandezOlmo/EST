using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeLever : Interactable
{
    public override void Interact()
    {
        GameEvents.ClearMissionText.Invoke();
        FindObjectOfType<EinsteinDomeSceneController>().OpenDome();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
