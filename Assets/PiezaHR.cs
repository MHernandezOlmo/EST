using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaHR : Interactable
{
    [SerializeField]
    int _pieza;
    bool _checked;
    [SerializeField] public DialogueTrigger _allPartsTrigger;
    public override void Interact()
    {
        GameProgressController.SetHRPiece(_pieza, true);
        int hramount = 0;

        for (int i = 0; i < 6; i++)
        {
            if (GameProgressController.GetHRPiece(i))
            {
                hramount++;
            }
        }
        if(hramount == 6)
        {
            GameEvents.ClearMissionText.Invoke();
            GameProgressController.GregorHasHeatRejecter = true;
            _allPartsTrigger.triggerDialogueEvent(true);
            if (FindObjectOfType<AlmacenGregorSceneController>() != null)
            {
                FindObjectOfType<AlmacenGregorSceneController>().InstantiatePC();
            }
        }
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtained: Heat rejecter\n" + hramount + "/6");

        Destroy(transform.root.gameObject);
    }
    private void Start()
    {
        base.Start();
        //for (int i = 0; i < 6; i++)
        //{
        //    GameProgressController.SetFiltro(i, false);
        //}
    }
    private void Update()
    {
        if (!_checked)
        {
            _checked = true;
            if (GameProgressController.GregorHasHeatRejecter)
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                Destroy(transform.root.gameObject);
            }
            else
            {
                if (GameProgressController.GetHRPiece(_pieza))
                {
                    FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                    Destroy(transform.root.gameObject);
                }
            }
        }
    }
}
