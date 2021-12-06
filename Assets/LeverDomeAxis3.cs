using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDomeAxis3 : Interactable
{
    public override void Interact()
    {
        FindObjectOfType<EinsteinDomeSceneController>().MoveAxis2();

    }
}
