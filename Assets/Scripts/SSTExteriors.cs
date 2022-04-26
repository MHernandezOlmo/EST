using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    void Start()
    {
        
        _shownAlert = GameProgressController.GetMicrowaveAlert();
        _microWaves = FindObjectsOfType<EnemyMicroWave>();
        _playerController = FindObjectOfType<PlayerController>();

        if(!GameProgressController.GetHasAO() && GameProgressController.GetHasShield())
        {
            AOPiecesCanvas.SetActive(true);
            _piecesAO = 0;
        }
    }
    public void GetPiece()
    {
        _piecesAO++;
        if(_piecesAO == 10)
        {
            GetAOTriggerDialog.triggerDialogueEvent();
            GameProgressController.SetHasAO(true);
        }
    }
    void Update()
    {
        _aoPiecesText.text = "Piezas conseguidas " + _piecesAO + "/10";
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
                //_dialogTrigger.triggerDialogueEvent();
                GameProgressController.SetMicrowaveAlert(true);
            }
        }
        
    }
}
