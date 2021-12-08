using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Lean.Localization
{
	/// <summary>This attribute allows you to select a translation from all the localizations in the scene.</summary>
	public class LeanTranslationDialogueAttribute : PropertyAttribute
	{
	}
}

#if UNITY_EDITOR
namespace Lean.Localization
{
	[CustomPropertyDrawer(typeof(LeanTranslationDialogueAttribute))]
	public class LeanTranslationDialogueDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var left = position; left.xMax -= 100;
			var center = position; center.xMin = left.xMax + 2; center.xMax = center.xMin + 40;
			var right = position; right.xMin = center.xMax + 2;
			var color = GUI.color;
			var alreadyAdded = new List<string>();
			var currentTranslations = LeanLocalizationEditorUtility.GetTranslations();

			EditorGUILayout.HelpBox("Only identifiers with dialogue suffix _00 are shown", MessageType.Info);

			if (!currentTranslations.Contains(property.stringValue + "_00"))
			{
				GUI.color = Color.red;
			}

			EditorGUI.PropertyField(left, property);

			GUI.color = color;

			if (GUI.Button(right, "Refresh"))
			{
				LeanLocalizationEditorUtility.ReloadTranslations();
				currentTranslations = LeanLocalizationEditorUtility.GetTranslations();
			}

			if (GUI.Button(center, "List"))
			{
				var menu = new GenericMenu();

				foreach (var translationName in currentTranslations)
				{
					/*if (Dialogue.IsDialogueID(translationName) && translationName.EndsWith("_00"))
					{
						var idWithoutSuffix = translationName.Remove(translationName.Length - 3);
						menu.AddItem(new GUIContent(idWithoutSuffix), property.stringValue == idWithoutSuffix, () => { property.stringValue = idWithoutSuffix; property.serializedObject.ApplyModifiedProperties(); });
					}*/
				}

				if (menu.GetItemCount() > 0)
				{
					menu.DropDown(right);
				}
				else
				{
					Debug.LogWarning("Your scene doesn't contain any phrases, so the phrase name list couldn't be created.");
				}
			}
		}
	}
}
#endif