using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionTextListener : MonoBehaviour
{
    private TextMeshProUGUI _missionsText;

    private void Start()
    {
        _missionsText = GetComponent<TextMeshProUGUI>();
        GameEvents.MissionText.AddListener(RefreshMission);
        GameEvents.ClearMissionText.AddListener(ClearMission);
        _missionsText.text = PlayerPrefs.GetString("Mission", "");
    }

    public void RefreshMission(string mission)
    {
        _missionsText.text = mission;
        PlayerPrefs.SetString("Mission", mission);
    }

    public void ClearMission()
    {
        _missionsText.text = "";
        PlayerPrefs.DeleteKey("Mission");
    }
}
