using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    public Transform _interactableMarker;

    public void Start()
    {
        FindObjectOfType<InteractablesController>().AddInteractable(this);
    }

    public Transform GetInteractableMarker()
    {
        return _interactableMarker;
    }

    public abstract void Interact();

}
