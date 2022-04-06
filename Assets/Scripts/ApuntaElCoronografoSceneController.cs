using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntaElCoronografoSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetIsPanelFixed(true);
        GameProgressController.SetCurrentStartPoint(3);
        GameEvents.LoadScene.Invoke("PicDuMidi_9_paneles_d");
    }
}
