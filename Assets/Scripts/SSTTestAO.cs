using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTTestAO : Interactable
{
    private void Start()
    {
        base.Start();

        if (GameProgressController.SSTPuzzleTetrisAO || !(GameProgressController.SSTAOPieces==10))
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        GameEvents.ClearMissionText.Invoke();
        GameEvents.LoadScene.Invoke("SSTPuzzleTetrisAO");
    }
}
