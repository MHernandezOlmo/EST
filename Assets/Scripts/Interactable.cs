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
    public void RemoveInteractable()
    {
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(transform.parent.gameObject);
    }
    public Transform GetInteractableMarker()
    {
        return _interactableMarker;
    }

    public abstract void Interact();

}
