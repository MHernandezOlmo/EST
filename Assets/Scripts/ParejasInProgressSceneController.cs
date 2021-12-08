using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParejasInProgressSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetSolvedPuzzleParejas(true);
        GameProgressController.SetCurrentStartPoint(1);
        GameEvents.LoadScene.Invoke("PicDuMidi_9_paneles_d From SST");
    }
}
