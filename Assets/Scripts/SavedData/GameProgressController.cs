using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class GameProgressController : MonoBehaviour
{
    public static GameProgressData _gameProgressData;
    
    const string _gameProgressDataFileName = "GameProgressData.json";

    public static bool GetIsLomnickySolved()
    {
        CheckInitialized();
        return _gameProgressData._isLomnickySolved;
    }
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
    public static bool ToastersAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._toastersAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._toastersAdvice = value;
            SaveGameProgressData();
        }
    }

    public static bool CoronalAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._coronalEjectionAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._coronalEjectionAdvice = value;
            SaveGameProgressData();
        }
    }
    public static bool NeedContactUV
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._needContactUV;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._needContactUV = value;
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

    public static bool FindFiltersAdvice
    {
        get
        {
            CheckInitialized();
            return _gameProgressData._findFiltersAdvice;
        }
        set
        {
            CheckInitialized();
            _gameProgressData._findFiltersAdvice = value;
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



    public static void SetIsLomickySolved(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._isLomnickySolved = newValue;
        SaveGameProgressData();
    }
    
    public static bool GetHasTornadoSkill()
    {
        CheckInitialized();
        return _gameProgressData._hasTornadoesSkill;
    }

    public static void SetHasTornadoSkill(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasTornadoesSkill = newValue;
        SaveGameProgressData();
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

    public static bool GetHasPrismEinstein()
    {
        CheckInitialized();
        return _gameProgressData._hasPrismEinstein;
    }
    public static void SetHasPrismEinstein(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasPrismEinstein = newValue;
        SaveGameProgressData();
    }
    public static bool GetEinsteinTowerFirstAdvice()
    {
        CheckInitialized();
        return _gameProgressData._einsteinTowerFirstAdvice;
    }
    public static void SetEinsteinTowerFirstAdvice(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._einsteinTowerFirstAdvice = newValue;
        SaveGameProgressData();
    }

    public static bool GetNeedsPrismEinstein()
    {
        CheckInitialized();
        return _gameProgressData._needPrismEinstein;
    }
    public static void SetNeedsPrismEinstein(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._needPrismEinstein= newValue;
        SaveGameProgressData();
    }

    public static bool GetUsedPrismEinstein()
    {
        CheckInitialized();
        return _gameProgressData._usedPrismEinstein;
    }
    public static void SetUsedPrismEinstein(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._usedPrismEinstein= newValue;
        SaveGameProgressData();
    }

    public static bool GetShownPrismDialog()
    {
        CheckInitialized();
        return _gameProgressData._shownPrismDialog;
    }
    
    public static void SetShownPrismDialog(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._shownPrismDialog = newValue;
        SaveGameProgressData();
    }


    public static bool GetCorrectPositionSotanoAxis0()
    {
        CheckInitialized();
        return _gameProgressData._correctPositionSotanoAxis0;
    }

    public static void SetCorrectPositionSotanoAxis0(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._correctPositionSotanoAxis0 = newValue;
        SaveGameProgressData();
    }
    public static void SetCorrectPositionSotanoAxis1(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._correctPositionSotanoAxis1 = newValue;
        SaveGameProgressData();
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
    public static bool GetCorrectPositionSotanoAxis1()
    {
        CheckInitialized();
        return _gameProgressData._correctPositionSotanoAxis1;
    }

    public static bool GetCorrectPositionAxis0()
    {
        CheckInitialized();
        return _gameProgressData._correctPositionAxis0;
    }
    public static bool GetCorrectPositionAxis1()
    {
        CheckInitialized();
        return _gameProgressData._correctPositionAxis1;
    }

    public static bool GetCorrectPositionAxis2()
    {
        CheckInitialized();
        return _gameProgressData._correctPositionAxis2;
    }

    public static void SetCorrectPositionAxis0(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._correctPositionAxis0 = newValue;
        SaveGameProgressData();
    }
    public static void SetCorrectPositionAxis1(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._correctPositionAxis1 = newValue;
        SaveGameProgressData();
    }
    public static void SetCorrectPositionAxis2(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._correctPositionAxis2 = newValue;
        SaveGameProgressData();
    }
    public static bool GetIsFullRayWorking()
    {
        CheckInitialized();
        bool fullRay = _gameProgressData._correctPositionAxis0 && _gameProgressData._correctPositionAxis1 && _gameProgressData._correctPositionAxis2;
        return fullRay;
    } 

    public static bool GetIsRayCrossingBasement()
    {
        CheckInitialized();
        return GetIsFullRayWorking() && _gameProgressData._correctPositionSotanoAxis0 && _gameProgressData._correctPositionSotanoAxis1;
    }

    public static bool GetHasOpenBarrierEinstein()
    {
        CheckInitialized();

        return _gameProgressData._hasOpenBarrierEinstein;
    }
    public static void SetHasOpenBarrierEinstein(bool newValue)
    {
        CheckInitialized();

        _gameProgressData._hasOpenBarrierEinstein = newValue;
        SaveGameProgressData();
    }
    public static bool GetNeedMirrorEinstein()
    {
        CheckInitialized();
        return _gameProgressData._needMirrorEinstein;
    }
    public static void SetNeedMirrorEinstein(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._needMirrorEinstein= newValue;
        SaveGameProgressData();
    }

    public static bool GetHasMirrorEinstein()
    {
        CheckInitialized();
        return _gameProgressData._hasMirrorEinstein;
    }
    public static void SetHasMirrorEinstein(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasMirrorEinstein= newValue;
        SaveGameProgressData();
    }

    public static bool GetUsedMirrorEinstein()
    {
        CheckInitialized();
        return _gameProgressData._usedMirrorEinstein;
    }
    public static void SetUsedMirrorEinstein(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._usedMirrorEinstein = newValue;
        SaveGameProgressData();
    }


    public static bool GetHasOpenDomeEinstein()
    {
        CheckInitialized();

        return _gameProgressData._hasDomeOpenEinstein;

    }
    public static void SetHasOpenDomeEinstein(bool newValue)
    {
        CheckInitialized();

        _gameProgressData._hasDomeOpenEinstein = newValue;
        SaveGameProgressData();

    }

    public static bool GetAdvisedCoronograph()
    {
        CheckInitialized();
        return _gameProgressData._advisedCoronograph;
    }
    public static bool GetHasSolarCanon()
    {
        CheckInitialized();
        return _gameProgressData._hasSolarCanon;
    }
    public static void SetHasSolarCanon(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasSolarCanon = newValue;
        SaveGameProgressData();
    }
    public static void SetAdvisedCoronograph(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._advisedCoronograph = newValue;
        SaveGameProgressData();
    }
    public static bool GetAsociacionElementos()
    {
        CheckInitialized();
        return _gameProgressData._asociacionElementosSolved;
    }
    public static void SetAsociacionElementos(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._asociacionElementosSolved = newValue;
        SaveGameProgressData();
    }
    public static bool GetPlatformLeft()
    {
        CheckInitialized();
        return _gameProgressData._floatingPlatformLeft;
    }
    public static void SetPlatformLeft(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._floatingPlatformLeft = newValue;
        SaveGameProgressData();
    }

    public static bool GetHasAbrigo()
    {
        CheckInitialized();
        return _gameProgressData._hasPicDuMidiAbrigo;
    }
    public static void SetHasAbrigo(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasPicDuMidiAbrigo = newValue;
        SaveGameProgressData();
    }
    public static bool GetHasGlasses()
    {
        CheckInitialized();
        return _gameProgressData._hasPicDuMidiGlasses;
    }
    public static void SetHasGlasses(bool newValue)
    {
        CheckInitialized();
        _gameProgressData._hasPicDuMidiGlasses = newValue;
        SaveGameProgressData();
    }
    public static bool GetPiezaCamara(int pieza)
    {
        CheckInitialized();
        return _gameProgressData._piezasCamara[pieza];
    }
    public static bool GetFiltro(int filtro)
    {
        CheckInitialized();
        return _gameProgressData._filtros[filtro];
    }
    public static void SetArrivedToPicDuMidi(bool value)
    {
        CheckInitialized();
        _gameProgressData._hasArrivedToPicDuMidi = value;
        SaveGameProgressData();
    }
    public static bool getArrivedToPicDuMudi()
    {
        CheckInitialized();
        return _gameProgressData._hasArrivedToPicDuMidi;
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
    public static bool GetRecopiledDataAdvice()
    {
        CheckInitialized();
        return _gameProgressData._recopiledDataAdvice;
    }
    public static void SetRecopiledDataAdvice(bool value)
    {
        CheckInitialized();
        _gameProgressData._recopiledDataAdvice = value;
        SaveGameProgressData();
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
    public static bool GetUncovered()
    {
        CheckInitialized();
        return _gameProgressData._uncovered;

    }
    public static bool HasAllFilters()
    {
        CheckInitialized();
        bool hasFilters = true;
        for(int i = 0; i< 6; i++)
        {
            if (!_gameProgressData._filtros[i])
            {
                hasFilters = false;
            }
        }
        return hasFilters;

    }
    public static void SetUncovered(bool state)
    {
        CheckInitialized();
        _gameProgressData._uncovered = state;
        SaveGameProgressData();
    }
    public static bool GetSalaCombateCombate()
    {
        CheckInitialized();
        return _gameProgressData._salaCombateCombate;
    }
    public static void SetPiezaCamara(int pieza, bool state)
    {
        CheckInitialized();
        _gameProgressData._piezasCamara[pieza] = state;
        SaveGameProgressData();
    }
    public static void SetFiltro(int pieza, bool state)
    {
        CheckInitialized();
        _gameProgressData._filtros[pieza] = state;
        SaveGameProgressData();
    }
    public static bool IsChoosePhenomenomSolved()
    {
        CheckInitialized();
        return _gameProgressData._choosePhenomenomSolved;
    }
    public static void SetChoosePhenomenomSolved(bool newState)
    {
        CheckInitialized();
        _gameProgressData._choosePhenomenomSolved = newState;
        SaveGameProgressData();
    }
    public static bool IsCazadoresDeFlaresSolved()
    {
        CheckInitialized();
        return _gameProgressData._cazadorDeFlaresSolved;
    }
    public static void SetCazadoresDeFlaresSolved(bool newState)
    {
        CheckInitialized();
        _gameProgressData._cazadorDeFlaresSolved= newState;
        SaveGameProgressData();
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
    public static bool IsCeilingClosed()
    {
        CheckInitialized();

        return _gameProgressData._closedCeiling;
    }
    public static void SetCeilingClosed(bool newState)
    {
        CheckInitialized();

        _gameProgressData._closedCeiling = newState;
        SaveGameProgressData();

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

    public static bool GetCountdown()
    {
        CheckInitialized();
        return _gameProgressData._countdownActive;
    }
    public static DateTime GetCountDownTime()
    {
        CheckInitialized();
        DateTime countDownStart = DateTime.FromBinary(Convert.ToInt64(_gameProgressData._countDownStartTime));
        return countDownStart;
    }
    public static void SetCountdownActive(bool newState)
    {
        CheckInitialized();
        _gameProgressData._countdownActive = newState;
        if(newState == true)
        {
            _gameProgressData._countDownStartTime = System.DateTime.Now.ToBinary().ToString();
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

    public static bool IsMotorFixed()
    {
        CheckInitialized();
        return _gameProgressData._motorFixed;

    }

    public static void SetMotorFixed(bool state)
    {
        CheckInitialized();
        _gameProgressData._motorFixed = state;
        SaveGameProgressData();

    }

    public static bool HasDash()
    {
        CheckInitialized();
        return _gameProgressData._hasDash;
    }
    public static void SetHasDash(bool state)
    {
        CheckInitialized();
        _gameProgressData._hasDash = state;
        SaveGameProgressData();
    }
    public static bool HasFuse()
    {
        CheckInitialized();
        return _gameProgressData._hasFuse;
    }
    public static bool IsPanelFixed()
    {
        CheckInitialized();
        return _gameProgressData._isPanelFixed;
    }
    public static void SetIsPanelFixed(bool state)
    {
        CheckInitialized();
        _gameProgressData._isPanelFixed = state;
        SaveGameProgressData();
    }

    public static void SetHasFuse(bool state)
    {
        CheckInitialized();
        _gameProgressData._hasFuse = state;
        SaveGameProgressData();

    }
}
