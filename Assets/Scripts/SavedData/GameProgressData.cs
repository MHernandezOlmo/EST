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

    //PicDuMidi
    public bool _picDuMidiWelcome;
    public bool _picDuMidiCoat;
    public bool _picDuMidiGlasses;
    public bool _picDuMidiDashSkill;
    public bool _picDuMidiToastersAdvice;
    public bool _picDuMidiUncoveredJeanRoch;
    public bool _picDuMidiPuzzleCoronagraph;
    public bool _picDuMidiCoronalEjectionAdvice;
    public bool[] _picDuMidiFilters;
    public bool _picDuMidiNeedContactUV;
    public bool _picDuMidiFindFiltersAdvice;
    public bool _picDuMidiFloatingPlatformLeft;
    public bool _picDuMidiLaberynthDialog;
    public bool _picDuMidiPuzzleAssociation;
    public bool _picDuMidiAssociationSolvedAdvice;
    public bool _picDuMidiSolved;

    //SST
    public bool _SSTMicrowaveAlert;
    public bool _SSTHallAdvice;
    public bool _SSTColdSystemFixed;
    public bool _SSTVacuumSystemFixed;
    public bool _SSTColaborativeAlert;
    public bool _SSTPuzzlePairs;
    public bool _SSTAOPiezesAlertShown;
    public bool _SSTShieldSkill;
    public int _SSTAOPieces;
    public bool _SSTHasAO;
    public bool _SSTDomePiece;
    public bool _SSTPuzzleTetrisAO;
    public bool _SSTBackFromTetrisAdvice;
    public bool _SSTSolved;

    //Gregor
    public bool _gregorHeatAdvices;
    public bool _gregorPuzzlePaintTower;
    public bool _gregorJetpackSkill;
    public bool _gregorHasHeatRejecter;
    public bool _gregorPlacedHeatRejecter;
    public bool[] _gregorHRPieces;
    public bool _gregorTestedHR;

    public bool _gregorFinished;
    public bool _ESTFinished;
    public bool _arrivingRoomDoor;
    public bool _combatDoor;
    public bool _salaCombateCombate;
    public bool _gregorDome;

    public string _currentScene;
    public int _currentStartPoint;
    public bool _recopiledDataAdvicePDMD;

    public bool _openEinsteinBasementDoor;

    public bool _telescopeReady;


    public bool _sstCollaborativeCallSolved;

    public bool _solvedPuzzleParejas;


    public bool _solvedPuzzleAO;
    public bool _adviceHR;

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
        _gregorHRPieces= new bool[6];
        _picDuMidiFilters = new bool[6];
        _currentScene = "";
        _currentStartPoint = 0;
    }
}

