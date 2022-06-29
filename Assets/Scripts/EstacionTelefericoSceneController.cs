using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacionTelefericoSceneController : MonoBehaviour
{
    MovementController _player;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera _firstCamera;
    [SerializeField]
    Transform _autoPilotTarget0;
    [SerializeField] GameObject _combatCanvas;
    [SerializeField] GameObject _dialog;
    [SerializeField] GameObject _end;
    [SerializeField] private DialogueTrigger _auroraDialog;
    [SerializeField] private DialogueTrigger _lampDialog;
    [SerializeField] private DialogueTrigger _lampDialogFinal;
    LamparaBot[] _enemies;
    void Start()
    {
        _enemies = FindObjectsOfType<LamparaBot>();
        _player = FindObjectOfType<MovementController>();
        foreach(LamparaBot en in _enemies)
        {
            en.enabled = false;
            en.GetComponent<Animator>().enabled = false;
        }
        if (!GameProgressController.LomnickyPuzzleFlareHunters)
        {
            GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
            StartCoroutine(CrInitialCinematic());
            _dialog.SetActive(true);
            _end.SetActive(false);
        }
        else
        {
            _firstCamera.Priority = 0;
            if (GameProgressController.LomnickyPuzzleLayers)
            {
                _dialog.SetActive(false);
                _end.SetActive(true);
                StartCoroutine(CrFinalDialog());
            }
        }
    }

    IEnumerator CrInitialCinematic()
    {
        CurrentSceneManager._canMove = true;
        yield return new WaitForSeconds(2);
        _auroraDialog.triggerDialogueEvent(true);
    }
    IEnumerator CrFinalDialog()
    {
        yield return new WaitForSeconds(1);
        _lampDialogFinal.triggerDialogueEvent(true);
    }


    public void ChangeCameraPriority()
    {
        _firstCamera.Priority = 0;
        StartCoroutine(CrLampDialog());
    }

    IEnumerator CrLampDialog()
    {
        yield return new WaitForSeconds(3);
        _lampDialog.triggerDialogueEvent();
    }

    public void RestoreEnemies()
    {
        foreach (LamparaBot en in _enemies)
        {
            en.enabled = true;
            en.GetComponent<Animator>().enabled = true;
        }
    }

}
