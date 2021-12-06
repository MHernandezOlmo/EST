using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleferico : Interactable
{
    public override void Interact()
    {
        if (GameProgressController.IsMotorFixed())
        {
            PlayerPrefs.SetInt("CinematicOpenCupula", 1);
            GameEvents.LoadScene.Invoke("Lomnicky_10_Azotea");
        }
        else
        {
            GameEvents.ShowScreenText.Invoke("You must repair the cable car engine to go up!");
        }
    }
}
