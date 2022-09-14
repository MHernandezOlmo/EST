using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegresoTeleferico : Interactable
{
    public override void Interact()
    {
        if (GameProgressController.LomnickyPuzzleLayers)
        {
            GameEvents.ClearMissionText.Invoke();
            GameProgressController.SetCurrentStartPoint(1);
            GameEvents.LoadScene.Invoke("Lomnicky_1_Estacion teleferico");
        }
    }
    private void Start()
    {
        if (!GameProgressController.LomnickyPuzzleLayers)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.root.gameObject);
        }
        else
        {
            FindObjectOfType<InteractablesController>().AddInteractable(this);
        }
    }
}
