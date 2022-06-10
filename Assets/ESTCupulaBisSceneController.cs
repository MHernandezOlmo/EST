using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTCupulaBisSceneController : MonoBehaviour
{
    
    IEnumerator Start()
    {
        GameProgressController.ESTDomeOpen = true;
        yield return new WaitForSeconds(3f);
        GameEvents.LoadScene.Invoke("EST_HRyAbrirCupula");
        GameProgressController.SetCurrentStartPoint(1);
    }

    void Update()
    {
        
    }
}
