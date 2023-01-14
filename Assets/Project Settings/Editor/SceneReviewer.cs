using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Lean.Localization;

public class SceneReviewer : MonoBehaviour
{
    [MenuItem("CustomTools/SceneIterator")]
    static void IterateThroughScenes()
    {
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            EditorSceneManager.OpenScene(scene.path);
            LeanMultilanguageCSV lean = FindObjectOfType<LeanMultilanguageCSV>();
            if (lean != null)
            {
                TextAsset t = Resources.Load<TextAsset>("LocalizationData/FinalTranslations");
                print(t);
                lean.Source = t;
                lean.LoadFromSource();
            }
            EditorSceneManager.SaveOpenScenes();
        }
    }


}
