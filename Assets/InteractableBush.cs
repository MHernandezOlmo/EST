using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBush : Interactable
{
    private ExterioresGregorSceneController _exterioresGregorSceneController;

    private void Start()
    {
        _exterioresGregorSceneController = FindObjectOfType<ExterioresGregorSceneController>();
        _interactableMarker.gameObject.SetActive(false);
    }
    public void EnableInteractable()
    {
        FindObjectOfType<InteractablesController>().AddInteractable(this);
        _interactableMarker.gameObject.SetActive(true);

    }
    public override void Interact()
    {
        _exterioresGregorSceneController.AddBush();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject);
    }
}