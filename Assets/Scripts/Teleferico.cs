using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleferico : Interactable
{
    public override void Interact()
    {
        if (GameProgressController.LomnickyMotor)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.LMetalDoor);
            PlayerPrefs.SetInt("CinematicOpenCupula", 1);
            GameEvents.LoadScene.Invoke("Lomnicky_10_Azotea");
        }
        else
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.LRedLight);
            GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("Alert/RepairEngine"));

            
        }
    }
}
