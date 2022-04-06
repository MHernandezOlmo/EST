using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCObservacionInteractable : Interactable
{
    public bool picDuMidi;
    public override void Interact()
    {
        if (picDuMidi)
        {
            GameEvents.LoadScene.Invoke("CoronografoInProgress");
        }
        else
        {
            GameEvents.LoadScene.Invoke("CazaFlares");

        }
    }

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }
}
