using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeEnfriamientoInProgressSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetIsSSTColdSystemFixed(true);
        GameProgressController.SetCurrentStartPoint(2);

        GameEvents.LoadScene.Invoke("SST_3_sala_maquinas");
    }
}
