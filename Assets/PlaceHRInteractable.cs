using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHRInteractable : Interactable
{
    DialogueTrigger _dialogToTrigger;
    bool _interacted;
    public override void Interact()
    {
        if (!_interacted)
        {
            GameEvents.ClearMissionText.Invoke();
            _interacted = true;
            FindObjectOfType<ExterioresGregorDome>().PlaceHR();
            if (FindObjectOfType<CountdownCanvas>() != null)
            {
                Destroy(FindObjectOfType<CountdownCanvas>().transform.parent.gameObject);
            }
        }
    }
}
