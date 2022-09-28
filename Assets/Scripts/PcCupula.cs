using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcCupula : Interactable
{
    private bool _havePieces;
    private bool _solved;
    public override void Interact()
    {
        if (_havePieces)
        {
            GameEvents.ClearMissionText.Invoke();
            GameEvents.LoadScene.Invoke("LomnickyPuzzleLayers");    
        } 
    }

    private void Start()
    {
        base.Start();

        if (GameProgressController.LomnickyPuzzleLayers)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
        else
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
                _havePieces = true;
            }
            if (!_havePieces)
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                GetComponent<SpriteRenderer>().enabled = false;
            }  
        }
        

    }

    private void Update()
    {
        if (!_havePieces)
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
                _havePieces = true;
                FindObjectOfType<InteractablesController>().AddInteractable(this);
                GetComponent<SpriteRenderer>().enabled = true;

            }
        }
    }

}
