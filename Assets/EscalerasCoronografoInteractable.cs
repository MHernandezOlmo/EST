using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasCoronografoInteractable :Interactable
{
    [SerializeField] DialogueTrigger _trigger;
    bool canInteract;
    bool restoring;
    public override void Interact()
    {
        if (canInteract)
        {
            canInteract = false;
            if (GameProgressController.HasAllFilters())
            {
                GameEvents.LoadScene.Invoke("AsociacionElementosInProgress");
            }
            else
            {
                _trigger.triggerDialogueEvent();

            }
        }
        if (CurrentSceneManager._state== GameStates.Exploration)
        {
            if (!restoring)
            {
                restoring = true;
                StartCoroutine(RestoreInteract());
            }
        }
    }
    IEnumerator RestoreInteract()
    {
        yield return new WaitForSeconds(0.2f);
        canInteract = true;
        restoring = false;
    }
    
}
