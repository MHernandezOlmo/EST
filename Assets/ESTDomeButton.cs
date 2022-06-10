using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTDomeButton : Interactable
{
    [SerializeField] private int _buttonIndex;

    private void Start()
    {
        base.Start();
        if (!GameProgressController.Mirror)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        FindObjectOfType<ESTCupulaSceneController>().PressButton(_buttonIndex);
    }
}