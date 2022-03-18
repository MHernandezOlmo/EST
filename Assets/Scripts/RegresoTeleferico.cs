using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegresoTeleferico : Interactable
{
    public override void Interact()
    {
        if (GameProgressController.IsChoosePhenomenomSolved())
        {
            GameEvents.LoadScene.Invoke("MainMenu");
        }
    }
    private void Start()
    {
        if (!GameProgressController.IsChoosePhenomenomSolved())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.root.gameObject);
        }
    }
}
