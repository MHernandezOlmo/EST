using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionCanvasController : MonoBehaviour
{
    private TextMeshProUGUI _missionsText;

    void Start()
    {
        _missionsText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        RefreshMissionPanel();
    }

    public void RefreshMissionPanel()
    {
        if (!GameProgressController.ESTGenerador)
        {
            _missionsText.text = "Turn the generator on";
            return;
        }
        if (!GameProgressController.ESTDomeOpen)
        {
            _missionsText.text = "Open the dome";
            return;
        }
        if (!GameProgressController.ESTAireM1M2)
        {
            _missionsText.text = "Switch on M1 and M2 air streams";
            return;
        }
        if (!GameProgressController.ESTMirrorsM3M6)
        {
            _missionsText.text = "Refill the coolant of M3-M6 mirrors";
            return;
        }
        if (!GameProgressController.ESTOA)
        {
            _missionsText.text = "Calibrate the Adaptive Optics System";
            return;
        }
        if (!GameProgressController.ESTHR)
        {
            _missionsText.text = "Activate the heat rejecter";
            return;
        }
        gameObject.SetActive(false);
    }

    public void HideMission()
    {
        _missionsText.text = "";
    }
}
