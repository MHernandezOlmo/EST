using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeInteractableGregorDome : Interactable
{
    [SerializeField] private string _sceneName;
    [SerializeField] private int _startingPoint;
    [SerializeField] private DialogueTrigger _trigger;
    bool _interacted;
    public override void Interact()
    {
        if (!_interacted)
        {
            _interacted = true;
            _trigger.triggerDialogueEvent(true);
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

    public void LaunchPanel()
    {
        PlayerPrefs.SetInt("BlockDoor",1);
        //GameEvents.ShowScreenText.Invoke("<size=80%>Find the tunnels to GREGOR from the VTT telescope");
    }
}
