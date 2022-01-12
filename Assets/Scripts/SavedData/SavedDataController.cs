using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Lean.Localization;
public class SavedDataController : MonoBehaviour
{
    static UserData _userData;
    static PreferencesData _preferencesData;
    
    const string _userDataFileName = "UserData.json";
    const string _preferencesDataFileName = "PreferencesData.json";

    public static bool IsInitialized()
    {
        bool hasPlayerData = File.Exists(Application.persistentDataPath + "/" + _userDataFileName);
        bool hasPreferencesData = File.Exists(Application.persistentDataPath + "/" + _preferencesDataFileName);
        bool hasEverything = hasPlayerData && hasPreferencesData;
        return hasEverything;
    }
    public static void SetLanguage(string newLanguage)
    {
        CheckInitialized();
        _preferencesData._language = newLanguage;
        SavePreferencesData();
    }
    public static string GetLanguage()
    {
        CheckInitialized();
        return _preferencesData._language;
    }
    public static void SetOSTEnabled(bool isEnabled)
    {
        CheckInitialized();
        _preferencesData._ostEnabled = isEnabled;
        SavePreferencesData();
    }
    public static void SetSFXEnabled(bool isEnabled)
    {
        CheckInitialized();
        _preferencesData._sfxEnabled = isEnabled;
        SavePreferencesData();
    }
    public static bool IsOSTEnabled()
    {
        CheckInitialized();
        return _preferencesData._ostEnabled;
    }
    public static bool IsSFXEnabled()
    {
        CheckInitialized();
        return _preferencesData._sfxEnabled;
    }
    public static void Initialize()
    {
        _userData = new UserData();
        Debug.Log(FindObjectOfType<LeanLocalizationController>());
        _preferencesData = new PreferencesData(FindObjectOfType<LeanLocalizationController>().GetCurrentLanguage());
        SaveAll();
    }
    public static void CheckInitialized()
    {
        if (!IsInitialized())
        {
            Initialize();
        }
        else
        {
            if(_userData==null || _preferencesData==null)
            {
                LoadAll();
            }
        }
    }
    static void SaveAll()
    {
        SaveUserData();
        SavePreferencesData();
    }
    static void LoadAll()
    {
        LoadUserData();
        LoadPreferencesData();
    }
    static void LoadPreferencesData()
    {
        _preferencesData = JsonUtility.FromJson<PreferencesData>(File.ReadAllText(Application.persistentDataPath + "/" + _preferencesDataFileName));
    }
    static void LoadUserData()
    {
        _userData = JsonUtility.FromJson<UserData>(File.ReadAllText(Application.persistentDataPath + "/" + _userDataFileName)); 
    }
    static void SavePreferencesData()
    {
        File.WriteAllText(Application.persistentDataPath+"/" + _preferencesDataFileName, JsonUtility.ToJson(_preferencesData));
    }
    static void SaveUserData()
    {
        File.WriteAllText(Application.persistentDataPath + "/" + _userDataFileName, JsonUtility.ToJson(_userData));

    }

}
