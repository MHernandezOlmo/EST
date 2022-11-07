using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gafas : Interactable
{
    public void Awake()
    {
        if (GameProgressController.PicDuMidiGlasses)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        GameProgressController.PicDuMidiGlasses = true;
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("<b>Obtained Sunglasses:</b>\n Block UV radiation");
        if (GameProgressController.PicDuMidiCoat)
        {
            GameEvents.ClearMissionText.Invoke();
        }
        Destroy(gameObject);
    }
}
