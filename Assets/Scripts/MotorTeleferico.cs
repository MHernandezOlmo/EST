using Lean.Localization;
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
            if (!GameProgressController.LomnickyMotor)
            {
                if (!GameProgressController.LomnickyFuse)
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
                    GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("Alert/FixEngine"));
                    GetComponent<AudioSource>().Play();
                    GameProgressController.LomnickyMotor = true;
                }
            }
            else
            {
                GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("Alert/FixedEngineInteract"));
            }
        }
    }
    public void ShowText()
    {
        GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("Alert/FindFuse"));

    }

    private void Start()
    {
        base.Start();
        if (GameProgressController.LomnickyMotor)
        {
            GetComponent<AudioSource>().Play();
            _shake.enabled = true;
        }
        if (GameProgressController.LomnickyPuzzleLayers)
        {
            //GameObject.Find("InteractButton").SetActive(false);
            RemoveInteractable();
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
