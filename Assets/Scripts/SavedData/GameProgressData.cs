using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameProgressData
{

    //LOMNICKY
    public bool _lomnickyTornadoSkill;
    public bool _lomnickyFuse;
    public bool _lomnickyMotor;
    public bool _lomnickyClosedCeiling;
    public bool _lomnickyCountdown;
    public float _lomnickyCountdownTime;
    public bool _lomnickyPuzzleFlareHunters;
    public bool _lomnickyRecopiledDataAdvice;
    public bool[] _lomnickyPiezasCamara;
    public bool _lomnickyPuzzleLayers;
    public bool _lomnickySolved;

    //Einstein
    public bool _einsteinSolarCanonSkill;
    public bool _einsteinOpenBarrier;
    public bool _einsteinTowerFirstAdvice;
    public bool _einsteinDomeOpen;
    public bool _einsteinNeedMirror;
    public bool _einsteinHasMirror;
    public bool _einsteinPlacedMirror;
    public bool _einsteinDomeAxis0;
    public bool _einsteinDomeAxis1;
    public bool _einsteinDomeAxis2;
    public bool _einsteinBasementAxis0;
    public bool _einsteinBasementAxis1;
    public bool _einsteinNoPrismDialog;
    public bool _einsteinNeedPrism;
    public bool _einsteinHasPrism;
    public bool _einsteinUsedPrism;
    public bool _einsteinSolved;

    public bool _picdumidiFinished;
    public bool _gregorFinished;
    public bool _SSTFinished;
    public bool _ESTFinished;
    public bool _arrivingRoomDoor;
    public bool _combatDoor;
    public bool[] _piezasHeatRejecter;
    public bool _heatRejecter;
    public bool _heatRejecterPlaced;
    public bool[] _filtros;
    public bool _salaCombateCombate;
    public bool _gregorDome;

    public string _currentScene;
    public int _currentStartPoint;
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
    public bool _toastersAdvice;
    public bool _coronalEjectionAdvice;
    public bool _topPiecePicked;

    public bool _openEinsteinBasementDoor;

    public bool _needContactUV;
    public bool _findFiltersAdvice;
    public bool _telescopeReady;
    public bool _jetpack;

    public bool _parejas;
    public bool _tetris;
    public bool _paintTower;
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

    public bool _hasReadHeatMessages;

    public bool _solvedPuzzleAO;
    public bool _adviceHR;
    public bool _testedHR;

    public bool _estGenerador;
    public bool _estFirstAdvice;
    public bool _estDomeOpen;
    public bool _estSecondAdvice;
    public bool _estAireM1M2;
    public bool _estOA;
    public bool _estMirror0;
    public bool _estMirror1;
    public bool _estMirror2;
    public bool _estMirror3;
    public bool _mirrorsM3M6;
    public bool _estHR;
    public bool _mirror;
    public bool _mirrorAdvice;

    public GameProgressData()
    {
        _lomnickyPiezasCamara = new bool[6];
        _piezasHeatRejecter= new bool[6];
        _filtros = new bool[6];
        _currentScene = "";
        _currentStartPoint = 0;
    }
}

