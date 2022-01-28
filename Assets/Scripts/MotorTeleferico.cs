using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorTeleferico : Interactable
{
    string _textKeyToShow;
    bool _interact;
    [SerializeField]
    Shake _shake;
    [SerializeField]
    GameObject _fusible;
    [SerializeField] DialogueTrigger _dialogue;

    bool _canInteract;
    bool _isInstantiated;
    public override void Interact()
    {
        if (_canInteract)
        {
            if (!GameProgressController.IsMotorFixed())
            {
                if (!GameProgressController.HasFuse())
                {
                    
                    _dialogue.triggerDialogueEvent(true);
                    if (!_isInstantiated)
                    {
                        _isInstantiated = true;
                        Instantiate(_fusible, new Vector3(-8.12f, 2.04f, 83.35f), Quaternion.Euler(-6.111f, -2.469f, 19.633f));
                    }
                    _canInteract = false;
                }
                else
                {
                    _shake.enabled = true;
                    GameEvents.ShowScreenText.Invoke("Motor is working again!");
                    GetComponent<AudioSource>().Play();
                    GameProgressController.SetMotorFixed(true);
                }
            }
            else
            {
                GameEvents.ShowScreenText.Invoke("I can now use the funicular");
            }
        }
    }
    public void ShowText()
    {
        GameEvents.ShowScreenText.Invoke("The solar storm has burned the fuse. Find a new one.");
    }
    private void Start()
    {
        base.Start();
        if (GameProgressController.IsMotorFixed())
        {
            GetComponent<AudioSource>().Play();
            _shake.enabled = true;
        }
    }

    private void Update()
    {
        if (!_canInteract)
        {
            if (CurrentSceneManager._state != GameStates.Dialogue)
            {
                _canInteract = true;
            }
        }
    }
}
