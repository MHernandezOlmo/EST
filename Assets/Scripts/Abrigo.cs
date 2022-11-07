using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrigo : Interactable
{
    public void Awake()
    {
        if (GameProgressController.PicDuMidiCoat)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        GameProgressController.PicDuMidiCoat = true;
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("<b>Obtained Coat:</b>\n Blocks IR radiation");
        if (GameProgressController.PicDuMidiGlasses)
        {
            GameEvents.ClearMissionText.Invoke();
        }
        Destroy(gameObject);
    }
}
