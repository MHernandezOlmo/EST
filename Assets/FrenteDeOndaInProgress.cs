using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenteDeOndaInProgress : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetSolvedAOPuzzle(true);
        GameProgressController.SetCurrentStartPoint(1);
        GameEvents.LoadScene.Invoke("SST_4_sala_observacion");
    }
}
