using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashRoomSceneController : MonoBehaviour
{
    public void ShowSkillText()
    {
        GameEvents.ShowScreenText.Invoke("Obtained: Flare Skill");
    }
}
