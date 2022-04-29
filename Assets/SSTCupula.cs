using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SSTCupula : MonoBehaviour
{
    [SerializeField] private GameObject AOPiecesCanvas;
    [SerializeField] private DialogueTrigger GetAOTriggerDialog;
    [SerializeField] TextMeshProUGUI _aoPiecesText;

    int _piecesAO;
    private void Start()
    {
        if (!GameProgressController.GetHasAO() && GameProgressController.GetHasShield())
        {
            AOPiecesCanvas.SetActive(true);
            _piecesAO = GameProgressController.GetPiezasAO();
        }
    }
    public void GetPiece()
    {
        _piecesAO++;
        GameProgressController.AddPiezaAO();
        if (_piecesAO == 10)
        {
            GetAOTriggerDialog.triggerDialogueEvent();
            GameProgressController.SetHasAO(true);
        }
    }
    private void Update()
    {
        _aoPiecesText.text = "AO pieces: " + _piecesAO + "/10";

    }
}
