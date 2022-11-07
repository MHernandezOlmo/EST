using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeEnfriamientoInProgressSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SSTColdSystemFixed = true;
        GameProgressController.SetCurrentStartPoint(2);
        if (GameProgressController.SSTVacuumSystemFixed)
        {
            GameEvents.ClearMissionText.Invoke();
        }
        GameEvents.LoadScene.Invoke("SST_3_sala_maquinas");
    }
}
