using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;

public class UserDataEditor : EditorWindow
{
    GameProgressData _gameProgressData;
    const string _gameProgressDataFileName = "GameProgressData.json";

    [MenuItem("Window/GameProgress")]
    public static void ShowWindow()
    {
        GetWindow(typeof(UserDataEditor));
    }
    bool _checked;

    private void OnGUI()
    {
        int height = 20;
        if (_checked)
        {

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Jetpack", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._jetpack = EditorGUILayout.Toggle(_gameProgressData._jetpack, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("HeatRejecter", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._heatRejecter = EditorGUILayout.Toggle(_gameProgressData._heatRejecter, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Placed HeatRejecter", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._heatRejecterPlaced = EditorGUILayout.Toggle(_gameProgressData._heatRejecterPlaced, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Gregor Dome", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._gregorDome = EditorGUILayout.Toggle(_gameProgressData._gregorDome, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Paint Tower", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._paintTower = EditorGUILayout.Toggle(_gameProgressData._paintTower, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Piezas HR", GUILayout.Height(height), GUILayout.Width(200));
            for (int i = 0; i < _gameProgressData._piezasHeatRejecter.Length; i++)
            {
                _gameProgressData._piezasHeatRejecter[i] = EditorGUILayout.Toggle(_gameProgressData._piezasHeatRejecter[i], GUILayout.Height(height), GUILayout.Width(20));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("AdviceHR", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._adviceHR = EditorGUILayout.Toggle(_gameProgressData._adviceHR, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Has Shield", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasShield= EditorGUILayout.Toggle(_gameProgressData._hasShield, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("TestedHR", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._testedHR = EditorGUILayout.Toggle(_gameProgressData._testedHR, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Has AO", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasAO = EditorGUILayout.Toggle(_gameProgressData._hasAO, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Piezas AO", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._piezasAO= EditorGUILayout.IntField(_gameProgressData._piezasAO, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Save Data"))
            {
                File.WriteAllText(Application.persistentDataPath + "/" + _gameProgressDataFileName, JsonUtility.ToJson(_gameProgressData));
                _checked = false;

            }

            if (GUILayout.Button("Clear Data"))
            {
                _checked = false;
            }
        }
        else
        {
            if (GUILayout.Button("Load User Data Values"))
            {
                LoadGameProgressData();
            }
        }

    }

    void LoadGameProgressData()
    {
        _gameProgressData = JsonUtility.FromJson<GameProgressData>(File.ReadAllText(Application.persistentDataPath + "/" + _gameProgressDataFileName));
        _checked = true;
    }

}
