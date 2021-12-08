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
            GUILayout.Label("Solved Lomnicky", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._isLomnickySolved = EditorGUILayout.Toggle(_gameProgressData._isLomnickySolved, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Tornado Skill", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasTornadoesSkill = EditorGUILayout.Toggle(_gameProgressData._hasTornadoesSkill, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Tiene Fusible", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasFuse = EditorGUILayout.Toggle(_gameProgressData._hasFuse, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Motor Arreglado", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._motorFixed = EditorGUILayout.Toggle(_gameProgressData._motorFixed, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Cuenta Atrás Activada", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._countdownActive = EditorGUILayout.Toggle(_gameProgressData._countdownActive, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Cúpula Cerrada", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._closedCeiling = EditorGUILayout.Toggle(_gameProgressData._closedCeiling, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Piezas Cámara", GUILayout.Height(height), GUILayout.Width(200));
            for (int i = 0; i < _gameProgressData._piezasCamara.Length; i++)
            {
                _gameProgressData._piezasCamara[i] = EditorGUILayout.Toggle(_gameProgressData._piezasCamara[i], GUILayout.Height(height), GUILayout.Width(20));
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Puerta de llegada abierta", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._arrivingRoomDoor = EditorGUILayout.Toggle(_gameProgressData._arrivingRoomDoor, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Puerta de combate abierta", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._combatDoor = EditorGUILayout.Toggle(_gameProgressData._combatDoor, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Puzzle Flares Resuelto", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._cazadorDeFlaresSolved = EditorGUILayout.Toggle(_gameProgressData._cazadorDeFlaresSolved, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Puzzle Fenomeno Resuelto", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._choosePhenomenomSolved = EditorGUILayout.Toggle(_gameProgressData._choosePhenomenomSolved, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("CurrentScene", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._currentScene = EditorGUILayout.TextField(_gameProgressData._currentScene, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Starting Point", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._currentStartPoint = EditorGUILayout.IntField(_gameProgressData._currentStartPoint, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("RecopiledData Advice", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._recopiledDataAdvice = EditorGUILayout.Toggle(_gameProgressData._recopiledDataAdvice, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Has Solar Canon", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasSolarCanon= EditorGUILayout.Toggle(_gameProgressData._hasSolarCanon, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Barrera einstein abierta", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasOpenBarrierEinstein = EditorGUILayout.Toggle(_gameProgressData._hasOpenBarrierEinstein, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Aviso torre Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._einsteinTowerFirstAdvice = EditorGUILayout.Toggle(_gameProgressData._einsteinTowerFirstAdvice, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Cúpula einstein abierta", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasDomeOpenEinstein = EditorGUILayout.Toggle(_gameProgressData._hasDomeOpenEinstein, GUILayout.Height(height), GUILayout.Width(20));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("IsPanelFixed", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._isPanelFixed = EditorGUILayout.Toggle(_gameProgressData._isPanelFixed, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Need Mirror Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._needMirrorEinstein= EditorGUILayout.Toggle(_gameProgressData._needMirrorEinstein, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Has Mirror Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasMirrorEinstein = EditorGUILayout.Toggle(_gameProgressData._hasMirrorEinstein, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Used Mirror Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._usedMirrorEinstein= EditorGUILayout.Toggle(_gameProgressData._usedMirrorEinstein, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Correct Position Axis 0", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._correctPositionAxis0 = EditorGUILayout.Toggle(_gameProgressData._correctPositionAxis0, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Correct Position Axis 1", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._correctPositionAxis1 = EditorGUILayout.Toggle(_gameProgressData._correctPositionAxis1, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Correct Position Axis 2", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._correctPositionAxis2 = EditorGUILayout.Toggle(_gameProgressData._correctPositionAxis2, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Correct Position Sotano Axis 0 ", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._correctPositionSotanoAxis0 = EditorGUILayout.Toggle(_gameProgressData._correctPositionSotanoAxis0, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Correct Position Sotano Axis 1", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._correctPositionSotanoAxis1 = EditorGUILayout.Toggle(_gameProgressData._correctPositionSotanoAxis1, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("EinsteinBasementDoor", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._openEinsteinBasementDoor= EditorGUILayout.Toggle(_gameProgressData._openEinsteinBasementDoor, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Need Prism Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._needPrismEinstein= EditorGUILayout.Toggle(_gameProgressData._needPrismEinstein, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Has Prism Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasPrismEinstein= EditorGUILayout.Toggle(_gameProgressData._hasPrismEinstein, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Used Prism Einstein", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._usedPrismEinstein= EditorGUILayout.Toggle(_gameProgressData._usedPrismEinstein, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Shown Prism Dialog", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._shownPrismDialog= EditorGUILayout.Toggle(_gameProgressData._shownPrismDialog, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Shown Mircrowave Alert", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._microwaveAlert = EditorGUILayout.Toggle(_gameProgressData._microwaveAlert, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Shown First SST Entry Alert", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._firstSSTEntry= EditorGUILayout.Toggle(_gameProgressData._firstSSTEntry, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Is Vacuum Solved", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._isVacuumSolved= EditorGUILayout.Toggle(_gameProgressData._isVacuumSolved, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Is SST Cold System Fixed", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._isSSTColdSystemFixed= EditorGUILayout.Toggle(_gameProgressData._isSSTColdSystemFixed, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Is SST Collaborative Alert Shown", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._sstColaborativeAlert= EditorGUILayout.Toggle(_gameProgressData._sstColaborativeAlert, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Is SST Collaborative Scene Solved", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._sstCollaborativeCallSolved= EditorGUILayout.Toggle(_gameProgressData._sstCollaborativeCallSolved, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Solved Puzzle Parejas", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._solvedPuzzleParejas= EditorGUILayout.Toggle(_gameProgressData._solvedPuzzleParejas, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Adaptative Optic Piezes Alert Shown", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._adaptativeOpticPiezesAlertShown= EditorGUILayout.Toggle(_gameProgressData._adaptativeOpticPiezesAlertShown, GUILayout.Height(height), GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Has Shield", GUILayout.Height(height), GUILayout.Width(200));
            _gameProgressData._hasShield= EditorGUILayout.Toggle(_gameProgressData._hasShield, GUILayout.Height(height), GUILayout.Width(200));
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
