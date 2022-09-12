using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class SSTExteriors : MonoBehaviour
{
    EnemyMicroWave[] _microWaves;
    PlayerController _playerController;
    bool _shownAlert;
    [SerializeField] DialogueTrigger _dialogTrigger;
    [SerializeField] GameObject AOPiecesCanvas;
    int _piecesAO;
    [SerializeField] DialogueTrigger GetAOTriggerDialog;
    [SerializeField] TextMeshProUGUI _aoPiecesText;
    bool _ended;
    [SerializeField] private CinemachineVirtualCamera _firstCamera;
    [SerializeField] private CinemachineVirtualCamera _secondCamera;
    IEnumerator Start()
    {
        _shownAlert = GameProgressController.SSTMicrowaveAlert;
        _microWaves = FindObjectsOfType<EnemyMicroWave>();
        _playerController = FindObjectOfType<PlayerController>();
        
        if (!GameProgressController.SSTHasAO && GameProgressController.SSTShieldSkill)
        {
            yield return null;
            AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.Epic_5);
            AOPiecesCanvas.SetActive(true);
            _piecesAO = GameProgressController.SSTAOPieces;
        }
        if (!GameProgressController.SSTMicrowaveAlert)
        {
            yield return new WaitForSeconds(2);
            _firstCamera.Priority = 0;
        }
        else
        {
            _firstCamera.Priority = 0;
        }
    }
    public void GetPiece()
    {
        _piecesAO++;
        GameProgressController.SSTAOPieces++;
        if(_piecesAO == 10)
        {
            GetAOTriggerDialog.triggerDialogueEvent();
        }
    }
    void Update()
    {
        bool allDead = true;
        for(int i = 0; i< _microWaves.Length; i++)
        {
            if (_microWaves[i] != null)
            {
                allDead = false;
            }
        }
        if (allDead)
        {
            if (!_ended)
            {
                _ended = true;
                PlayerPrefs.SetInt("PieceToSecure", 4);
                GameEvents.LoadScene.Invoke("SecurePiece");
            }
        }
        _aoPiecesText.text = "AO pieces: " + _piecesAO + "/10";
        if (!_shownAlert)
        {
            float minDistance = 999f;
            for (int i = 0; i < _microWaves.Length; i++)
            {
                float auxDistance = Vector3.Distance(_microWaves[i].transform.position, _playerController.transform.position);
                if (auxDistance < minDistance)
                {
                    minDistance = auxDistance;
                }
            }
            if (minDistance < 15f)
            {
                _shownAlert = true;
                _dialogTrigger.triggerDialogueEvent();
                GameProgressController.SSTMicrowaveAlert =true;
            }
        }      
    }
}
