using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDomeAxis1 : Interactable
{
    public void Awake()
    {
        if (GameProgressController.GetOpenEinsteinBasementDoor())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        FindObjectOfType<EinsteinDomeSceneController>().MoveAxis0();
    }
}
