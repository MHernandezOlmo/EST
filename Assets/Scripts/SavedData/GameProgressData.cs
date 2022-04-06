using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameProgressData
{
    public bool _isLomnickySolved;
    public bool _hasTornadoesSkill;
    public bool _hasFuse;
    public bool _motorFixed;
    public bool _countdownActive;
    public string _countDownStartTime;
    public bool _closedCeiling;
    public bool _arrivingRoomDoor;
    public bool _combatDoor;
    public bool _cazadorDeFlaresSolved;
    public bool _choosePhenomenomSolved;
    public bool[] _piezasCamara;
    public bool[] _filtros;
    public bool _salaCombateCombate;
    public string _currentScene;
    public int _currentStartPoint;
    public bool _recopiledDataAdvice;
    public bool _recopiledDataAdvicePDMD;
    public bool _hasArrivedToPicDuMidi;
    public bool _hasDash;
    public bool _isPanelFixed;
    public bool _uncovered;
    public bool _hasPicDuMidiAbrigo;
    public bool _hasPicDuMidiGlasses;
    public bool _advisedCoronograph;
    public bool _floatingPlatformLeft;
    public bool _asociacionElementosSolved;
    public bool _hasSolarCanon;
    public bool _hasOpenBarrierEinstein;
    public bool _hasDomeOpenEinstein;
    public bool _needMirrorEinstein;
    public bool _hasMirrorEinstein;
    public bool _usedMirrorEinstein;
    public bool _correctPositionAxis0;
    public bool _correctPositionAxis1;
    public bool _correctPositionAxis2;
    public bool _toastersAdvice;
    public bool _coronalEjectionAdvice;

    public bool _correctPositionSotanoAxis0;
    public bool _correctPositionSotanoAxis1;

    public bool _openEinsteinBasementDoor;

    public bool _shownPrismDialog;
    public bool _needContactUV;
    public bool _findFiltersAdvice;
    public bool _telescopeReady;

    public bool _needPrismEinstein;
    public bool _hasPrismEinstein;
    public bool _usedPrismEinstein;
    public bool _einsteinTowerFirstAdvice;
    public bool _parejas;
    public bool _microwaveAlert;
    public bool _firstSSTEntry;
    public bool _isVacuumSolved;
    public bool _isSSTColdSystemFixed;

    public bool _sstColaborativeAlert;
    public bool _sstCollaborativeCallSolved;

    public bool _solvedPuzzleParejas;

    public bool _adaptativeOpticPiezesAlertShown;

    public bool _hasShield;

    public int _piezasAO;

    public bool _hasAO;

    public bool _solvedPuzzleAO;
    public GameProgressData()
    {
        _hasArrivedToPicDuMidi = false;
        _recopiledDataAdvice = true;
        _salaCombateCombate = false;
        _hasFuse = false;
        _motorFixed = false;
        _countdownActive = false;
        _closedCeiling = false;
        _cazadorDeFlaresSolved = false;
        _piezasCamara = new bool[6];
        _filtros = new bool[6];
        _currentScene = "";
        _currentStartPoint = 0;
        _countDownStartTime = DateTime.Now.ToBinary().ToString();
        _choosePhenomenomSolved = false;
        _hasDash = false;
        _hasPicDuMidiGlasses = false;
        _hasPicDuMidiAbrigo = false;
        _advisedCoronograph = false;
        _floatingPlatformLeft = false;
        _asociacionElementosSolved = false;
    }

}

