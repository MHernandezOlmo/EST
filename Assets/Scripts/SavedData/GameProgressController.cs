using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class GameProgressController : MonoBehaviour
{
    public static GameProgressData _gameProgressData;
    
    const string _gameProgressDataFileName = "GameProgressData.json";

    #region Lomnicky

    public static bool LomnickyTornadoSkill
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyTornadoSkill;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyTornadoSkill = value;
            SaveGameProgressData();
        }
    }
    public static bool LomnickyFuse
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyFuse;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyFuse=value;
            SaveGameProgressData();
        }

    }
    public static bool LomnickyMotor
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyMotor;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyMotor = value;
            SaveGameProgressData();
        }

    }

    public static bool LomnickyClosedCeiling
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyClosedCeiling;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyClosedCeiling = value;
            SaveGameProgressData();
        }

    }
    public static bool LomnickyCountdown
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyCountdown;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyCountdown = value;
            SaveGameProgressData();
        }
    }
    public static float LomnickyCountdownTime
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyCountdownTime;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyCountdownTime = value;
            SaveGameProgressData();
        }
    }

    public static bool LomnickyPuzzleFlareHunters
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyPuzzleFlareHunters;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyPuzzleFlareHunters = value;
            SaveGameProgressData();
        }
    }

    public static bool LomnickyRecopiledDataAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyRecopiledDataAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyRecopiledDataAdvice = value;
            SaveGameProgressData();
        }
    }




    public static bool GetPiezaCamara(int pieza)
    {
        CheckInitialized();
        return _gameProgressData._lomnickyPiezasCamara[pieza];
    }

    public static void SetPiezaCamara(int pieza, bool state)
    {
        CheckInitialized();
        _gameProgressData._lomnickyPiezasCamara[pieza] = state;
        SaveGameProgressData();
    }

    public static bool LomnickyPuzzleLayers
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickyPuzzleLayers;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickyPuzzleLayers = value;
            SaveGameProgressData();
        }
    }
    public static bool LomnickySolved
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._lomnickySolved;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._lomnickySolved = value;
            SaveGameProgressData();
        }
    }


    public static bool IsArrivingRoomDoorOpen()
    {
        CheckInitialized();
        return _gameProgressData._arrivingRoomDoor;
    }
    public static void SetArrivingRoomDoor(bool newState)
    {
        CheckInitialized();
        _gameProgressData._arrivingRoomDoor = newState;
        SaveGameProgressData();

    }
    public static bool IsCombatRoomDoorOpen()
    {
        CheckInitialized();
        return _gameProgressData._combatDoor;
    }
    public static void SetCombatRoomDoor(bool newState)
    {
        CheckInitialized();
        _gameProgressData._combatDoor = newState;
        SaveGameProgressData();

    }
    #endregion

    #region PicDuMidi
    public static bool PicDuMidiWelcome
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiWelcome;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiWelcome = value;
            SaveGameProgressData();
        }
    }
    public static bool PicDuMidiCoat
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiCoat;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiCoat = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiGlasses
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiGlasses;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiGlasses = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiDashSkill
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiDashSkill;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiDashSkill = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiSolved
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiSolved;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiSolved = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiUncoveredJeanRoch
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiUncoveredJeanRoch;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiUncoveredJeanRoch = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiPuzzleCoronagraph
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiPuzzleCoronagraph;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiPuzzleCoronagraph = value;
            SaveGameProgressData();
        }
    }

   
    public static bool PicDuMidiCoronalEjectionAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiCoronalEjectionAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiCoronalEjectionAdvice = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiFindFiltersAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiFindFiltersAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiFindFiltersAdvice = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiToastersAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiToastersAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiToastersAdvice = value;
            SaveGameProgressData();
        }
    }

    public static bool GetPicDuMidiFilter(int filtro)
    {
        CheckInitialized();
        return _gameProgressData._picDuMidiFilters[filtro];
    }

    public static bool HasAllPicDuMidiFilters()
    {
        CheckInitialized();
        bool hasFilters = true;
        for (int i = 0; i < 6; i++)
        {
            if (!_gameProgressData._picDuMidiFilters[i])
            {
                hasFilters = false;
            }
        }
        return hasFilters;

    }

    public static void SetPicDuMidiFilter(int pieza, bool state)
    {
        CheckInitialized();
        _gameProgressData._picDuMidiFilters[pieza] = state;
        SaveGameProgressData();
    }
    public static bool PicDuMidiFloatingPlatformLeft
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiFloatingPlatformLeft;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiFloatingPlatformLeft = value;
            SaveGameProgressData();
        }
    }

    public static bool PicDuMidiPuzzleAssociation
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiPuzzleAssociation;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiPuzzleAssociation = value;
            SaveGameProgressData();
        }
    }
    public static bool PicDuMidiAssociationSolvedAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiAssociationSolvedAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiAssociationSolvedAdvice = value;
            SaveGameProgressData();
        }
    }

    #endregion

    #region Einstein
    public static bool EinsteinSolarCanonSkill
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinSolarCanonSkill;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinSolarCanonSkill = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinSolved
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinSolved;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinSolved = value;
            SaveGameProgressData();
        }
    }


    public static bool EinsteinOpenBarrier
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinOpenBarrier;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinOpenBarrier = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinTowerFirstAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinTowerFirstAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinTowerFirstAdvice = value;
            SaveGameProgressData();
        }
    }

    public static bool EinsteinDomeOpen
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinDomeOpen;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinDomeOpen = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinNeedMirror
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinNeedMirror;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinNeedMirror = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinHasMirror
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinHasMirror;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinHasMirror = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinPlacedMirror
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinPlacedMirror;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinPlacedMirror = value;
            SaveGameProgressData();
        }
    }


    public static bool EinsteinDomeAxis0
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinDomeAxis0;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinDomeAxis0 = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinDomeAxis1
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinDomeAxis1;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinDomeAxis1 = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinDomeAxis2
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinDomeAxis2;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinDomeAxis2 = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinBasementAxis0
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinBasementAxis0;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinBasementAxis0 = value;
            SaveGameProgressData();
        }
    }

    public static bool EinsteinBasementAxis1
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinBasementAxis1;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinBasementAxis1 = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinNoPrismDialog
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinNoPrismDialog;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinNoPrismDialog = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinNeedPrism
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinNeedPrism;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinNeedPrism = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinHasPrism
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinHasPrism;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinHasPrism = value;
            SaveGameProgressData();
        }
    }
    public static bool EinsteinUsedPrism
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._einsteinUsedPrism;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._einsteinUsedPrism = value;
            SaveGameProgressData();
        }
    }






    public static bool GetOpenEinsteinBasementDoor()
    {
        CheckInitialized();
        return _gameProgressData._openEinsteinBasementDoor;
    }

    public static void SetOpenEinsteinBasementDoor(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._openEinsteinBasementDoor = newValue;
        SaveGameProgressData();
    }

    public static bool GetIsFullRayWorking()
    {
        CheckInitialized();
        bool fullRay = _gameProgressData._einsteinDomeAxis0 && _gameProgressData._einsteinDomeAxis1 && _gameProgressData._einsteinDomeAxis2;
        return fullRay;
    }

    public static bool GetIsRayCrossingBasement()
    {
        CheckInitialized();
        return GetIsFullRayWorking() && _gameProgressData._einsteinBasementAxis0 && _gameProgressData._einsteinBasementAxis1;
    }

    #endregion

    #region SST
    public static bool SSTMicrowaveAlert
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTMicrowaveAlert;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTMicrowaveAlert = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTHallAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTHallAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTHallAdvice = value;
            SaveGameProgressData();
        }
    }

    public static bool SSTColdSystemFixed
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTColdSystemFixed;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTColdSystemFixed = value;
            SaveGameProgressData();
        }
    }

    public static bool SSTVacuumSystemFixed
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTVacuumSystemFixed;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTVacuumSystemFixed = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTColaborativeAlert
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTColaborativeAlert;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTColaborativeAlert = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTPuzzlePairs
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTPuzzlePairs;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTPuzzlePairs = value;
            SaveGameProgressData();
        }
    }

    public static bool SSTAOPiezesAlertShown
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTAOPiezesAlertShown;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTAOPiezesAlertShown = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTShieldSkill
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTShieldSkill;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTShieldSkill = value;
            SaveGameProgressData();
        }
    }

    public static int SSTAOPieces
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTAOPieces;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTAOPieces = value;
            SaveGameProgressData();
        }
    }

    public static bool SSTHasAO
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTHasAO;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTHasAO = value;
            SaveGameProgressData();
        }
    }

    public static bool SSTDomePiece
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTDomePiece;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTDomePiece = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTPuzzleTetrisAO
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTPuzzleTetrisAO;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTPuzzleTetrisAO = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTBackFromTetrisAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTBackFromTetrisAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTBackFromTetrisAdvice = value;
            SaveGameProgressData();
        }
    }
    public static bool SSTSolved
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTSolved;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTSolved = value;
            SaveGameProgressData();
        }
    }
    #endregion

    #region GREGOR
    public static bool GregorHeatAdvices
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorHeatAdvices;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorHeatAdvices = value;
            SaveGameProgressData();
        }
    }

    public static bool GregorHasHeatRejecter
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorHasHeatRejecter;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorHasHeatRejecter = value;
            SaveGameProgressData();
        }
    }

    public static bool GregorPlacedHeatRejecter
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorPlacedHeatRejecter;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorPlacedHeatRejecter = value;
            SaveGameProgressData();
        }
    }

    public static bool GregorDome
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorDome;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorDome = value;
            SaveGameProgressData();
        }
    }
    public static bool GregorTestedHR
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorTestedHR;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorTestedHR = value;
            SaveGameProgressData();
        }
    }
    public static bool GregorFinished
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorFinished;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorFinished = value;
            SaveGameProgressData();
        }
    }
    public static bool AdviceHR
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._adviceHR;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._adviceHR = value;
            SaveGameProgressData();
        }
    }

    #endregion

    #region EST
    public static bool ESTGenerador
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estGenerador;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estGenerador = value;
            SaveGameProgressData();
        }
    }

    public static bool MirrorAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._mirrorAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._mirrorAdvice = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTOA
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estOA;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estOA = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTMirror0
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estMirror0;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estMirror0 = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTMirror1
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estMirror1;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estMirror1 = value;
            SaveGameProgressData();
        }
    }

    public static bool ESTMirror2
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estMirror2;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estMirror2 = value;
            SaveGameProgressData();
        }
    }

    public static bool ESTMirror3
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estMirror3;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estMirror3 = value;
            SaveGameProgressData();
        }
    }

    public static bool ESTMirrorsM3M6
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._mirrorsM3M6;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._mirrorsM3M6 = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTHR
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estHR;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estHR = value;
            SaveGameProgressData();
        }
    }
    public static bool Mirror
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._mirror;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._mirror = value;
            SaveGameProgressData();
        }
    }

    public static bool ESTAireM1M2
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estAireM1M2;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estAireM1M2 = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTDomeOpen
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estDomeOpen;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estDomeOpen = value;
            SaveGameProgressData();
        }
    }

    public static bool ESTSecondAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estSecondAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estSecondAdvice = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTFirstAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._estFirstAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._estFirstAdvice = value;
            SaveGameProgressData();
        }
    }
    public static bool ESTFinished
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._ESTFinished;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._ESTFinished = value;
            SaveGameProgressData();
        }
    }
    #endregion


   



    
    
    public static bool PicDuMidiNeedContactUV
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._picDuMidiNeedContactUV;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._picDuMidiNeedContactUV = value;
            SaveGameProgressData();
        }
    }


    public static bool GregorPuzzlePaintTower
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorPuzzlePaintTower;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorPuzzlePaintTower = value;
            SaveGameProgressData();
        }
    }
    public static bool GregorJetpackSkill
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._gregorJetpackSkill;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._gregorJetpackSkill = value;
            SaveGameProgressData();
        }
    }

    public static bool GetHRPiece(int pieza)
    {
        CheckInitialized();
        return _gameProgressData._gregorHRPieces[pieza];
    }
    public static void SetHRPiece(int pieza, bool value)
    {
        CheckInitialized();
        _gameProgressData._gregorHRPieces[pieza] = value;
        SaveGameProgressData();
    }
    public static bool TelescopeReady
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._telescopeReady;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._telescopeReady = value;
            SaveGameProgressData();
        }
    }
    

    public static void SetSolvedAOPuzzle(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._solvedPuzzleAO = newValue;
        SaveGameProgressData();
    }


    public static bool GetSolvedPuzzleParejas()
    {
        CheckInitialized();
        return _gameProgressData._solvedPuzzleParejas;
    }

    public static void SetSolvedPuzzleParejas(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._solvedPuzzleParejas = newValue;
        SaveGameProgressData();
    }

    public static bool GetSSTCollaborativeSceneSolved()
    {
        CheckInitialized();
        return _gameProgressData._sstCollaborativeCallSolved;
    }

    public static void SetSSTCollaborativeSceneSolved(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._sstCollaborativeCallSolved = newValue;
        SaveGameProgressData();
    }
















    public static void Reset()
    {
        CheckInitialized();
        _gameProgressData = new GameProgressData();
        SaveGameProgressData();
    }
    public static void SetCurrentScene(string sceneName)
    {
        CheckInitialized();
        _gameProgressData._currentScene = sceneName;
        SaveGameProgressData();
    }
    public static void SetCurrentStartPoint(int startPoint)
    {
        CheckInitialized();
        _gameProgressData._currentStartPoint = startPoint;
        SaveGameProgressData();
    }
    public static int GetStartPoint()
    {
        CheckInitialized();
        return _gameProgressData._currentStartPoint;

    }

    public static bool GetRecopiledDataAdvicePDMD()
    {
        CheckInitialized();
        return _gameProgressData._recopiledDataAdvicePDMD;
    }
    public static void SetRecopiledDataAdvicePDMD(bool value)
    {
        CheckInitialized();
        _gameProgressData._recopiledDataAdvicePDMD = value;
        SaveGameProgressData();
    }
    public static string GetCurrentScene()
    {
        CheckInitialized();
        return _gameProgressData._currentScene;
    }

    public static void SetSalaCombateCombate()
    {
        CheckInitialized();
        _gameProgressData._salaCombateCombate = true;
        SaveGameProgressData();
    }
 
   


    public static bool GetSalaCombateCombate()
    {
        CheckInitialized();
        return _gameProgressData._salaCombateCombate;
    }



    

    public static bool IsInitialized()
    {
        bool hasGameProgressData = File.Exists(Application.persistentDataPath + "/" + _gameProgressDataFileName);
        bool hasEverything = hasGameProgressData;
        return hasEverything;
    }
    public static void CheckInitialized()
    {
        if (!IsInitialized())
        {
            Initialize();
        }
        else
        {
            if (_gameProgressData == null)
            {
                LoadAll();
            }
        }
    }

    static void LoadAll()
    {
        LoadGameProgressData();
    }
    static void LoadGameProgressData()
    {
        _gameProgressData = JsonUtility.FromJson<GameProgressData>(File.ReadAllText(Application.persistentDataPath + "/" + _gameProgressDataFileName));
    }
    static void SaveGameProgressData()
    {
        File.WriteAllText(Application.persistentDataPath + "/" + _gameProgressDataFileName, JsonUtility.ToJson(_gameProgressData));
    }
    public static void Initialize()
    {
        _gameProgressData = new GameProgressData();
        SaveGameProgressData();
    }

    





}
