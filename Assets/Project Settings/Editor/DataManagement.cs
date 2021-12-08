using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataManagement : MonoBehaviour
{

    const string _userDataFileName = "UserData.json";
    const string _preferencesDataFileName = "PreferencesData.json";
    const string _gameProgressFileName = "GameProgressData.json";

    [MenuItem("DataManagement/Open PersistentDataPath Folder")]
    public static void OpenPersistentDataPath()
    {
        EditorUtility.RevealInFinder(Application.persistentDataPath);
    }

    [MenuItem("DataManagement/Delete PersistentDataPath Data")]
    [SerializeField]
    public static void DeleteStreamingAssetsFolder()
    {
        File.Delete(Application.persistentDataPath + "/"+_userDataFileName);
        File.Delete(Application.persistentDataPath + "/"+_preferencesDataFileName);
        File.Delete(Application.persistentDataPath + "/" + _gameProgressFileName);
    }

    [MenuItem("DataManagement/DeletePlayerPrefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    [MenuItem("DataManagement/SetStartPoint/0")]
    public static void SetStartPoint0()
    {
        SetStartPoint(0);
    }
    [MenuItem("DataManagement/SetStartPoint/1")]
    public static void SetStartPoint1()
    {
        SetStartPoint(1);
    }
    [MenuItem("DataManagement/SetStartPoint/2")]
    public static void SetStartPoint2()
    {
        SetStartPoint(2);
    }
    [MenuItem("DataManagement/SetStartPoint/3")]
    public static void SetStartPoint3()
    {
        SetStartPoint(3);
    }
    public static void SetStartPoint(int p)
    {
        //PlayerPrefs.SetInt("PreviousPoint", p);
        GameProgressController.SetCurrentStartPoint(p);

    }
}
