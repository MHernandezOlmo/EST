using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEinstein : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] DialogueTrigger _dialog;
    
    private void Start()
    {
        base.Start();
        if (GameProgressController.EinsteinNeedMirror)
        {
            if (GameProgressController.EinsteinHasMirror)
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(this);
                Destroy(_animator.gameObject);
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
        else
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(_animator.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
        
    }
    public override void Interact()
    {
        GameEvents.ClearMissionText.Invoke();
        GameProgressController.EinsteinHasMirror = true;
        _animator.SetTrigger("Get");
        _dialog.triggerDialogueEvent();
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        Destroy(gameObject.transform.parent.gameObject);
        GameEvents.ShowScreenText.Invoke("Obtained: Mirror");
    }
}
