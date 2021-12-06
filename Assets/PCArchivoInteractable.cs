using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCArchivoInteractable : Interactable
{
    [SerializeField]
    DialogueTrigger _dialogToTrigger;
    bool _interacted;
    public override void Interact()
    {
        if (!_interacted)
        {
            _interacted = true;
            StartCoroutine(WaitAndInteract());
        }

    }
    IEnumerator WaitAndInteract()
    {
        yield return null;
        _dialogToTrigger.triggerDialogueEvent(true);
        yield return new WaitForSeconds(2f);
        while (CurrentSceneManager._state != GameStates.Exploration)
        {
            yield return null;
        }
        GameEvents.LoadScene.Invoke("SST_4_sala_observacion Lomnicky");
    }
    private void Start()
    {
        base.Start();
        if (GameProgressController.IsCazadoresDeFlaresSolved())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            gameObject.SetActive(false);
        }
    }
}
