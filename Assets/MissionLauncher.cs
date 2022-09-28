using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLauncher : MonoBehaviour
{
    public void NewMission(string missionName)
    {
        GameEvents.MissionText.Invoke(missionName);
    }
    public void ClearMission()
    {
        GameEvents.ClearMissionText.Invoke();
    }
}
