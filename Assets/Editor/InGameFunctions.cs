using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;

public class InGameFunctions : EditorWindow
{
    GameProgressData _gameProgressData;
    const string _gameProgressDataFileName = "GameProgressData.json";

    [MenuItem("Window/InGameFunctions")]
    public static void ShowWindow()
    {
        GetWindow(typeof(InGameFunctions));
    }
    bool _checked;
    bool _hasFuse;
    bool _motorFixed;
    string _countDownStartTime;
    bool _closedCeiling;
    bool _arrivingRoomDoor;
    bool _combatDoor;
    bool _cazadorDeFlaresSolved;
    bool[] _piezasCamara;
    private void OnGUI()
    {
        int height = 20;
        if (_checked)
        {
            //if (GUILayout.Button("Add Character Fragments", GUILayout.Width(200), GUILayout.Height(height)))
            //{
            //    FindObjectOfType<RewardManager>().EarnCharacterFragments(selectedCharacter, selectedCharacterFragments);
            //}

        }
    }
}

