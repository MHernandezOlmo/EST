using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasCoronografoInteractable :Interactable
{
    [SerializeField] DialogueTrigger _trigger;
    [SerializeField] DialogueTrigger _triggerStart;
    bool canInteract;
    bool restoring;
    public override void Interact()
    {
        canInteract = false;
        if (GameProgressController.HasAllFilters())
        {
            _triggerStart.triggerDialogueEvent(true);

        }
        else
        {
            _trigger.triggerDialogueEvent(true);
        }

    }
    public void LoadOtherScene()
    {
        GameEvents.LoadScene.Invoke("Parejas");
    }
    IEnumerator RestoreInteract()
    {
        yield return new WaitForSeconds(0.2f);
        canInteract = true;
        restoring = false;
    }
    private void Awake()
    {
        if (GameProgressController.Parejas)
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(gameObject);
        }
    }
}
