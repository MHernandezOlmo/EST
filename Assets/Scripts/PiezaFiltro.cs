﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaFiltro : Interactable
{
    [SerializeField]
    int _pieza;
    bool _checked;
    string[] _filterNames = new string[] { "H-Alpha", "G band", "Ca II H", "CN band", "TiO"}; 
    public override void Interact()
    {
        GameProgressController.SetPicDuMidiFilter(_pieza, true);
        int filterAmount=0;

        for (int i = 0;i< 5; i++)
        {
            if (GameProgressController.GetPicDuMidiFilter(i))
            {
                filterAmount++;
            }
        }
        if(filterAmount == 5)
        {
            StartCoroutine(CrMission());
            IEnumerator CrMission()
            {
                yield return new WaitForSeconds(4f);
                GameEvents.MissionText.Invoke("Test the filters at the telescope control room");
            }
        }
        GameEvents.ShowScreenText.Invoke("Obtained:\n" + _filterNames[_pieza]+" filter "+filterAmount+"/5");
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
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
