using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDomeAxis2 : Interactable
{
    public override void Interact()
    {
        FindObjectOfType<EinsteinDomeSceneController>().MoveAxis1();

    }
}

