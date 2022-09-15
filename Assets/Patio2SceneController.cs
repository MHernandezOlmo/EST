using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patio2SceneController : MonoBehaviour
{

    [SerializeField] private DialogueTrigger _dialog;

    void Start()
    {
        if (GameProgressController.PicDuMidiCoronalEjectionAdvice)
        {
            _dialog.gameObject.SetActive(false);
        }
    }

    public void ReadAdvice()
    {
        GameProgressController.PicDuMidiCoronalEjectionAdvice = true;
        GameEvents.ShowScreenText.Invoke("Use the coronagraph");
        _dialog.gameObject.SetActive(false);
    }
    public void ContactUV()
    {
        GameEvents.ShowScreenText.Invoke("Find a way to contact UV");
        GameProgressController.PicDuMidiNeedContactUV = true;
        GameEvents.ClearMissionText.Invoke();
    }
}
