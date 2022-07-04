using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaFiltro : Interactable
{
    [SerializeField]
    int _pieza;
    bool _checked;

    public override void Interact()
    {
        GameProgressController.SetPicDuMidiFilter(_pieza, true);
        int filterAmount=0;

        for (int i = 0;i< 6; i++)
        {
            if (GameProgressController.GetPicDuMidiFilter(i))
            {
                filterAmount++;
            }
        }
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtained: Filter\n"+filterAmount+"/6");
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
            if (!GameProgressController.PicDuMidiPuzzleCoronagraph)
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                Destroy(transform.root.gameObject);
            }
            else
            {
                if (GameProgressController.GetPicDuMidiFilter(_pieza))
                {
                    FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                    Destroy(transform.root.gameObject);
                }
            }
        }
    }
}
