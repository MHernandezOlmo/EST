using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazadoresDeFlaresSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetCazadoresDeFlaresSolved(true);
        GameEvents.LoadScene.Invoke("Lomnicky_6_Sala Observacion SST");
    }
}
