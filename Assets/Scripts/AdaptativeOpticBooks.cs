using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptativeOpticBooks : Interactable
{
    [SerializeField] AdaptativeOpticBinder _binderController;

    private void Start()
    {
        base.Start();
        if (GameProgressController.GetSolvedPuzzleParejas())
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
            Destroy(transform.parent.gameObject);
        }
    }
    public override void Interact()
    {
        _binderController.OpenBinderCanvas();
    }

    public void LoadNextScene()
    {
        GameEvents.LoadScene.Invoke("PicDuMidi_9_paneles_d From SST");
    }
}
