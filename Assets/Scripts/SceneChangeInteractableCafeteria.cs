using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeInteractableCafeteria : Interactable
{
    [SerializeField] private string _sceneName;
    [SerializeField] private int _startingPoint;
    [SerializeField] DialogueTrigger trigger;
    bool _canExit;

    bool _interacted;
    public override void Interact()
    {
        if (!_canExit)
        {
            if (GameProgressController.GetHasAbrigo() && GameProgressController.GetHasGlasses())
            {
                _canExit = true;
            }
        }
        if (!_canExit)
        {
            trigger.triggerDialogueEvent(true);
        }
        else
        {
            _interacted = true;
            GameProgressController.SetCurrentStartPoint(_startingPoint);
            GameEvents.LoadScene.Invoke(_sceneName);
        }

    }
    IEnumerator WaitAndInteract()
    {
        yield return null;
        yield return new WaitForSeconds(2f);
    }
    private void Start()
    {
        base.Start();
        _interactableMarker = transform;
    }
}
