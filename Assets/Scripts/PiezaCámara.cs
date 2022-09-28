using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaCámara : Interactable
{
    [SerializeField]
    int _pieza;
    bool _checked;

    public override void Interact()
    {
        GameProgressController.SetPiezaCamara(_pieza, true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtained: Camera part");
        int pieces = 0;
        for (int i = 0; i < 6; i++)
        {
            if (GameProgressController.GetPiezaCamara(i))
            {
                pieces++;
            }
        }
        if (pieces == 6)
        {
            GameEvents.ClearMissionText.Invoke();
        }
        Destroy(transform.root.gameObject);
    }
    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        if (!_checked)
        {
            _checked = true;
            if (GameProgressController.GetPiezaCamara(_pieza))
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                Destroy(transform.root.gameObject);
            }
        }
    }
}
