using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesController : MonoBehaviour
{
    [SerializeField]
    List<Interactable> _allInteractables;
    PlayerController _playerController;
    int _currentInteractable;
    InteractableUIPoolController _interactableUIPoolController;
    void Start()
    {
        _currentInteractable = -1;
        _interactableUIPoolController = FindObjectOfType < InteractableUIPoolController>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        _currentInteractable = _interactableUIPoolController.GetSelectedInteractable();
    }
    public void AddInteractable(Interactable newInteractable)
    {
        if (_allInteractables == null)
        {
            _allInteractables = new List<Interactable>();
        }
        _allInteractables.Add(newInteractable);
    }
    //public void SetCurrentInteractable(int currentInteractableIndex)
    //{
    //    if (currentInteractableIndex >= 0)
    //    {
    //        GameEvents.CanInteract.Invoke(true);
    //    }
    //    else
    //    {
    //        GameEvents.CanInteract.Invoke(false);
    //    }

    //    _currentInteractable = currentInteractableIndex;
    //}
    public void RemoveInteractable(Interactable interactableToRemove)
    {
        _allInteractables.Remove(interactableToRemove);
    }
    public void Interact()
    {
        if (_currentInteractable >= 0)
        {
            _allInteractables[_currentInteractable].Interact();
            _currentInteractable = -1;
        }
    }
    public List<Interactable> GetAllInteractables()
    {
        return _allInteractables;
    }

}
