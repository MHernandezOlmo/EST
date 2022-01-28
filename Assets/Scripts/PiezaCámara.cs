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
        print(transform.root.gameObject.name);
        GameProgressController.SetPiezaCamara(_pieza, true);
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameEvents.ShowScreenText.Invoke("Obtained: Camera part");
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
