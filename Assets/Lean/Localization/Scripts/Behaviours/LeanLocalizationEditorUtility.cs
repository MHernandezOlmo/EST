using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class LeanLocalizationEditorUtility
{
#if UNITY_EDITOR
	[MenuItem("EST/Reload Translations")]
#endif
	public static void ReloadTranslations()
	{
#if UNITY_EDITOR
		var leanLocalizationPrefab = Resources.Load("LeanLocalization") as GameObject;
		leanLocalizationPrefab.GetComponentInChildren<LeanMultilanguageCSV>().LoadFromSource();
		PrefabUtility.SavePrefabAsset(leanLocalizationPrefab);
		EditorGUIUtility.PingObject(leanLocalizationPrefab);
		Debug.Log("[EST] Translations reloaded");
#endif
	}

	public static List<string> GetTranslations()
	{
		if (LeanLocalization.CurrentTranslations.Count > 0)
		{
			return LeanLocalization.CurrentTranslations.Keys.ToList();
		}
		else
		{
			return GetTranslationsFromMainPrefab();
		}
	}

	static List<string> GetTranslationsFromMainPrefab()
	{
		var leanLocalizationPrefab = Resources.Load("LeanLocalization") as GameObject;
		LeanMultilanguageCSV csvSource = leanLocalizationPrefab.GetComponentInChildren<LeanMultilanguageCSV>();
		List<string> arrayOfIds = new List<string>(csvSource.MultilanguageEntries.Count);

		foreach (LeanMultilanguageCSV.MultilanguageEntry multiEntry in csvSource.MultilanguageEntries)
		{
			arrayOfIds.Add(multiEntry.Name);
		}

		return arrayOfIds;
	}

	// static GameObject FindMainPrefab()
	// {
	// 	GameObject foundMain = null;
	// 	var matchingGUIDs = AssetDatabase.FindAssets("Main");
	// 	foreach (var guid in matchingGUIDs)
	// 	{
	// 		var path = AssetDatabase.GUIDToAssetPath(guid);
	// 		var obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
	// 		if (obj.GetComponent<Main>() != null)
	// 		{
	// 			foundMain = obj;
	// 			break;
	// 		}
	// 	}
	// 	return foundMain;
	// }

}