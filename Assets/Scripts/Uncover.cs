using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncover : Interactable
{
    void Start()
    {
        base.Start();
        if (!GameProgressController.PicDuMidiPuzzleCoronagraph)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        GameProgressController.PicDuMidiUncoveredJeanRoch = true;
        GameProgressController.SetCurrentStartPoint(1);
        GameEvents.LoadScene.Invoke("PicDuMidi_8_exterior_jeanrock");
    }
}