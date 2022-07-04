using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaObservacionSceneController : MonoBehaviour
{
    MovementController _player;
    [SerializeField]
    DialogueTrigger _dialogToTrigger;

    [SerializeField]
    DialogueTrigger _dialogToTriggerPicDuMidi;

    [SerializeField]
    Interactable _pc;
    bool _launchDialogue;
    bool _pdmd;

    void Awake()
    {
        _player = FindObjectOfType<MovementController>();
        _pdmd = PlayerPrefs.GetInt("ComingFromPDMD")>0;
        if (_pdmd)
        {
            FindObjectOfType<PCObservacionInteractable>().picDuMidi = true;
            PlayerPrefs.SetInt("ComingFromPDMD", 0);
            if (GameProgressController.PicDuMidiPuzzleCoronagraph)
            {
                _pc.gameObject.SetActive(false);
            }
        }
        else
        {
            if (GameProgressController.LomnickyPuzzleFlareHunters)
            {
                _pc.gameObject.SetActive(false);
            }
        }
        
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        if (_pdmd)
        {
            if (GameProgressController.PicDuMidiPuzzleCoronagraph)
            {
                if (!_launchDialogue)
                {
                    _launchDialogue = true;
                    _dialogToTriggerPicDuMidi.triggerDialogueEvent(true);
                    StartCoroutine(WaitForExploration());
                }
            }
        }
        else
        {
            if (GameProgressController.LomnickyPuzzleFlareHunters)
            {
                if (!_launchDialogue)
                {
                    _launchDialogue = true;
                    _dialogToTrigger.triggerDialogueEvent(true);
                    StartCoroutine(WaitForExploration());
                }
            }
        }
    }


    IEnumerator WaitForExploration()
    {
        while(CurrentSceneManager._state != GameStates.Exploration)
        {
            yield return null;
        }
        if (_pdmd)
        {
            GameProgressController.SetCurrentStartPoint(1);
            GameEvents.LoadScene.Invoke("PicDuMidi_9_paneles_d");
        }
        else
        {
            GameProgressController.SetCurrentStartPoint(2);
            GameEvents.LoadScene.Invoke("Lomnicky_5_Sala archivo");
        }
        
    }
}
