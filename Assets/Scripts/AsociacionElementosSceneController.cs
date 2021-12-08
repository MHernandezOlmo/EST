using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsociacionElementosSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetAsociacionElementos(true);
        GameProgressController.SetCurrentStartPoint(1);
        GameEvents.LoadScene.Invoke("PicDuMidi_14_Sala b");
    }
}
