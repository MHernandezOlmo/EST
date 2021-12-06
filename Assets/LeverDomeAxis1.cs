using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDomeAxis1 : Interactable
{
    public override void Interact()
    {
        FindObjectOfType<EinsteinDomeSceneController>().MoveAxis0();
    }
}
