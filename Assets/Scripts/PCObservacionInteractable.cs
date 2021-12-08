using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCObservacionInteractable : Interactable
{
    public bool picDuMidi;
    public override void Interact()
    {
        print("Si");
        if (picDuMidi)
        {
            GameEvents.LoadScene.Invoke("CoronografoInProgress");
        }
        else
        {
            print("Sehh");
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
