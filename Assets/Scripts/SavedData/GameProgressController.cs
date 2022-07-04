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
    public static bool SSTFinished
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._SSTFinished;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._SSTFinished = value;
            SaveGameProgressData();
        }
    }
    #endregion

    #region GREGOR
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
    public static bool PlaceHR
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._heatRejecterPlaced;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._heatRejecterPlaced = value;
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
    public static bool TestedHR
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._testedHR;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._testedHR = value;
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
    public static bool HeatMessages
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._hasReadHeatMessages;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._hasReadHeatMessages = value;
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
    public static bool TopPiecePicked
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._topPiecePicked;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._topPiecePicked = value;
            SaveGameProgressData();
        }
    }





   



    public static bool HeatRejecter
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._heatRejecter;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._heatRejecter = value;
            SaveGameProgressData();
        }
    }
    
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
    public static bool Parejas
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._parejas;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._parejas = value;
            SaveGameProgressData();
        }
    }
    public static bool Tetris
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._tetris;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._tetris = value;
            SaveGameProgressData();
        }
    }
    public static bool PaintTower
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._paintTower;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._paintTower = value;
            SaveGameProgressData();
        }
    }
    public static bool Jetpack
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._jetpack;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._jetpack = value;
            SaveGameProgressData();
        }
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
    
    public static int GetPiezasAO()
    {
        CheckInitialized();
        return _gameProgressData._piezasAO;
    }
    public static void SetPiezasAO(int piezes)
    {
        CheckInitialized();
        _gameProgressData._piezasAO = piezes;
        SaveGameProgressData();

    }
    public static void AddPiezaAO()
    {
        CheckInitialized();
        _gameProgressData._piezasAO++;
        SaveGameProgressData();
    }
    public static bool GetHasAO()
    {
        CheckInitialized();
        return _gameProgressData._hasAO;
    }

    public static bool GetSolvedAOPuzzle()
    {
        CheckInitialized();
        return _gameProgressData._solvedPuzzleAO;
    }

    public static void SetSolvedAOPuzzle(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._solvedPuzzleAO = newValue;
        SaveGameProgressData();
    }

    public static void SetHasAO(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasAO = newValue;
        SaveGameProgressData();
    }

    public static bool GetHasShield()
    {
        CheckInitialized();
        return _gameProgressData._hasShield;
    }

    public static void SetHasShield(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasShield = newValue;
        SaveGameProgressData();
    }
    public static bool GetAdaptativeOpticsPiezesAlertShown()
    {
        CheckInitialized();
        return _gameProgressData._adaptativeOpticPiezesAlertShown;
    }

    public static void SetAdaptativeOpticsPiezesAlertShown(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._adaptativeOpticPiezesAlertShown = newValue;
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

    public static bool GetSSTCollaborativeAlertShown()
    {
        CheckInitialized();
        return _gameProgressData._sstColaborativeAlert;
    }

    public static void SetSSTCollaborativeAlertShown(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._sstColaborativeAlert = newValue;
        SaveGameProgressData();
    }

    public static bool GetIsSSTColdSystemFixed()
    {
        CheckInitialized();
        return _gameProgressData._isSSTColdSystemFixed;
    }

    public static void SetIsSSTColdSystemFixed(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._isSSTColdSystemFixed = newValue;
        SaveGameProgressData();
    }

    public static bool GetIsVacuumSolved()
    {
        CheckInitialized();
        return _gameProgressData._isVacuumSolved;
    }

    public static void SetIsVacuumSolved(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._isVacuumSolved = newValue;
        SaveGameProgressData();
    }
    public static bool GetFistSSTEntry()
    {
        CheckInitialized();
        return _gameProgressData._firstSSTEntry;
    }

    public static void SetFirstSSTEntry(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._firstSSTEntry = newValue;
        SaveGameProgressData();
    }

    public static bool GetMicrowaveAlert()
    {
        CheckInitialized();
        return _gameProgressData._microwaveAlert;
    }

    public static void SetMicrowaveAlert(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._microwaveAlert = newValue;
        SaveGameProgressData();
    }






    public static bool GetPiezaHR(int pieza)
    {
        CheckInitialized();
        return _gameProgressData._piezasHeatRejecter[pieza];
    }
    public static void SetPiezaHR(int pieza, bool value)
    {
        CheckInitialized();
        _gameProgressData._piezasHeatRejecter[pieza] = value;
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
