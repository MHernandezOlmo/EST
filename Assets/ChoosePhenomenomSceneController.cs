using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePhenomenomSceneController : MonoBehaviour
{
    public void Continue()
    {
        GameProgressController.SetChoosePhenomenomSolved(true);
        GameEvents.LoadScene.Invoke("Lomnicky_11_Sala Cupula");

    }
}
