﻿using System.Collections;
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
    Vector2 scrollPosition = Vector2.zero;

    [MenuItem("Window/GameProgress")]
    public static void ShowWindow()
    {
        GetWindow(typeof(UserDataEditor));
    }
    bool _checked;

    private void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, true, true, GUILayout.Width(position.width), GUILayout.Height(position.height));
        int height = 20;
        if (_checked)
        {
            GUILayout.Label("Lomnicky", GUILayout.Height(height), GUILayout.Width(200));

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Tornado Skill", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyTornadoSkill= EditorGUILayout.Toggle(_gameProgressData._lomnickyTornadoSkill, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Fuse", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyFuse= EditorGUILayout.Toggle(_gameProgressData._lomnickyFuse, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Motor", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyMotor = EditorGUILayout.Toggle(_gameProgressData._lomnickyMotor, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Closed Ceiling", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyClosedCeiling= EditorGUILayout.Toggle(_gameProgressData._lomnickyClosedCeiling, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Countdown", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyCountdown= EditorGUILayout.Toggle(_gameProgressData._lomnickyCountdown, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Countdown Time", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyCountdownTime = EditorGUILayout.FloatField(_gameProgressData._lomnickyCountdownTime, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Puzzle Flare Hunters", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyPuzzleFlareHunters = EditorGUILayout.Toggle(_gameProgressData._lomnickyPuzzleFlareHunters, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Recopiled Data Advice", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyRecopiledDataAdvice = EditorGUILayout.Toggle(_gameProgressData._lomnickyRecopiledDataAdvice, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Camera Pieces", GUILayout.Height(height), GUILayout.Width(200));
            for (int i = 0; i < _gameProgressData._lomnickyPiezasCamara.Length; i++)
            {
                _gameProgressData._lomnickyPiezasCamara[i] = EditorGUILayout.Toggle(_gameProgressData._lomnickyPiezasCamara[i], GUILayout.Height(height), GUILayout.Width(20));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Lomnicky Puzzle Layers", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickyPuzzleLayers = EditorGUILayout.Toggle(_gameProgressData._lomnickyPuzzleLayers, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Lomnicky Solved", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._lomnickySolved = EditorGUILayout.Toggle(_gameProgressData._lomnickySolved, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            GuiLine();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._einsteinFinished = EditorGUILayout.Toggle(_gameProgressData._einsteinFinished, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("PicDuMidi", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._picdumidiFinished = EditorGUILayout.Toggle(_gameProgressData._picdumidiFinished, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Gregor", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._gregorFinished = EditorGUILayout.Toggle(_gameProgressData._gregorFinished, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("SST", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._SSTFinished = EditorGUILayout.Toggle(_gameProgressData._SSTFinished, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._ESTFinished = EditorGUILayout.Toggle(_gameProgressData._ESTFinished, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();


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


            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Generador", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estGenerador= EditorGUILayout.Toggle(_gameProgressData._estGenerador, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST First Advice", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estFirstAdvice = EditorGUILayout.Toggle(_gameProgressData._estFirstAdvice, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Dome Open", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estDomeOpen= EditorGUILayout.Toggle(_gameProgressData._estDomeOpen, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Second Advice", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estSecondAdvice= EditorGUILayout.Toggle(_gameProgressData._estSecondAdvice, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal(); 
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("ESTOA", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estOA = EditorGUILayout.Toggle(_gameProgressData._estOA, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Mirror0", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estMirror0= EditorGUILayout.Toggle(_gameProgressData._estMirror0, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Mirror1", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estMirror1 = EditorGUILayout.Toggle(_gameProgressData._estMirror1, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Mirror2", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estMirror2 = EditorGUILayout.Toggle(_gameProgressData._estMirror2, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Mirror3", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estMirror3 = EditorGUILayout.Toggle(_gameProgressData._estMirror3, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST Mirrors M3M6", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._mirrorsM3M6 = EditorGUILayout.Toggle(_gameProgressData._mirrorsM3M6, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST HR", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._estHR = EditorGUILayout.Toggle(_gameProgressData._estHR, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST MIRROR", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._mirror= EditorGUILayout.Toggle(_gameProgressData._mirror, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EST mirror advice", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._mirrorAdvice = EditorGUILayout.Toggle(_gameProgressData._mirrorAdvice, GUILayout.Height(height), GUILayout.Width(200));
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

            EditorGUILayout.EndScrollView();
    }
    void GuiLine(int i_height = 1)

    {

        Rect rect = EditorGUILayout.GetControlRect(false, i_height);

        rect.height = i_height;

        EditorGUI.DrawRect(rect, Color.black);

    }
    void LoadGameProgressData()
    {
        _gameProgressData = JsonUtility.FromJson<GameProgressData>(File.ReadAllText(Application.persistentDataPath + "/" + _gameProgressDataFileName));
        _checked = true;
    }

}
