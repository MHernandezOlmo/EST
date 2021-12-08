using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleVacioInProgressSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetIsVacuumSolved(true);
        GameProgressController.SetCurrentStartPoint(1);

        GameEvents.LoadScene.Invoke("SST_3_sala_maquinas");
    }
}
