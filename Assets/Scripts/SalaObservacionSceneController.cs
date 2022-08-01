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
    [SerializeField] private bool _pdmd;

    void Awake()
    {
        _player = FindObjectOfType<MovementController>();
        if (_pdmd)
        {
            FindObjectOfType<PCObservacionInteractable>().picDuMidi = true;
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
                }
            }
        }
    }

    public void LoadNextScene()
    {
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
