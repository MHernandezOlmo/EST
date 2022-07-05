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
        if (!GameProgressController.SSTHasAO && GameProgressController.SSTShieldSkill)
        {
            AOPiecesCanvas.SetActive(true);
            _piecesAO = GameProgressController.SSTAOPieces;
        }
    }
    public void GetPiece()
    {
        _piecesAO++;
        GameProgressController.SSTAOPieces++;
        if (_piecesAO == 10)
        {
            GetAOTriggerDialog.triggerDialogueEvent();
        }
    }
    private void Update()
    {
        _aoPiecesText.text = "AO pieces: " + _piecesAO + "/10";

    }
}
