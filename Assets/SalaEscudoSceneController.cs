using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaEscudoSceneController : MonoBehaviour
{
    private void Start()
    {
        if (!GameProgressController.SSTShieldSkill)
        {
            GameEvents.ClearMissionText.Invoke();
        }
    }
    public void Advice()
    {
        GameEvents.ShowScreenText.Invoke("Obtained: Magnetic shield skill");
    }
}
