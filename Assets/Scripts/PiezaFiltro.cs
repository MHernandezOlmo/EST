using System.Collections;
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
        GameEvents.ClearMissionText.Invoke();
        GameProgressController.SetPicDuMidiFilter(_pieza, true);
        int filterAmount=0;

        for (int i = 0;i< 5; i++)
        {
            if (GameProgressController.GetPicDuMidiFilter(i))
            {
                filterAmount++;
            }
        }
        GameEvents.ShowScreenText.Invoke("Obtained:\n" + _filterNames[_pieza] + " filter " + filterAmount + "/5");
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        if (filterAmount == 5)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            StartCoroutine(CrDestroy());
            IEnumerator CrDestroy()
            {
                Destroy(transform.parent.GetChild(0).gameObject);
                transform.parent.GetComponent<MeshRenderer>().enabled = false;
                yield return new WaitForSeconds(5f);
                GameEvents.MissionText.Invoke("Test the filters in the telescope control room");
                Destroy(transform.root.gameObject);
            }
        }
        else
        {
            Destroy(transform.root.gameObject);
        }
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
