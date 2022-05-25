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
        GameProgressController.SetPiezaHR(_pieza, true);
        int hramount = 0;

        for (int i = 0; i < 6; i++)
        {
            if (GameProgressController.GetPiezaHR(i))
            {
                hramount++;
            }
        }
        if(hramount == 6)
        {
            GameProgressController.HeatRejecter = true;
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
            if (GameProgressController.HeatRejecter)
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                Destroy(transform.root.gameObject);
            }
            else
            {
                if (GameProgressController.GetPiezaHR(_pieza))
                {
                    FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                    Destroy(transform.root.gameObject);
                }
            }
        }
    }
}
