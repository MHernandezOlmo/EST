using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedCanvasBehaviour : MonoBehaviour
{
    int _speedLevel;
    static float[] _speedLevelValues = new float[]{1f,1.1f,1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2f};
    [SerializeField] TextMeshProUGUI speedText;
    public void AddSpeed()
    {
        _speedLevel = Mathf.Min(_speedLevel + 1, _speedLevelValues.Length-1);
        CurrentSceneManager.SetWalkSpeed(_speedLevelValues[_speedLevel]);
    }
    public void SubstractSpeed()
    {
        _speedLevel = Mathf.Max(_speedLevel - 1, 0);
        CurrentSceneManager.SetWalkSpeed(_speedLevelValues[_speedLevel]);
    }


    void Update()
    {
        speedText.text = CurrentSceneManager.GetWalkSpeed().ToString();
    }
}
