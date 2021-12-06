using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPiecesCheck : MonoBehaviour
{
    [SerializeField]
    DialogueTrigger _dialogueTrigger;
    bool pieceses;
    bool havePieces;
    private void Start()
    {
        int pieces=0;
        for (int i = 0; i < 6; i++)
        {
            if (GameProgressController.GetPiezaCamara(i))
            {
                pieces++;
            }
        }
        if (pieces==6)
        {
            havePieces = true;
        }
        
    }

    private void Update()
    {
        if (!havePieces)
        {
            int piezasObtenidas = 0;
            for (int i = 0; i < 6; i++)
            {
                if (GameProgressController.GetPiezaCamara(i))
                {
                    piezasObtenidas++;
                }
            }
            if (piezasObtenidas == 6)
            {
                if (!pieceses)
                {
                    pieceses = true;
                    _dialogueTrigger.triggerDialogueEvent(true);
                }
            }
        }
    }
}
