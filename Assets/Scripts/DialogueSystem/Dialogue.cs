#pragma warning disable CS0649
using UnityEngine;
using UnityEngine.Events;
using Lean.Localization;

#if UNITY_EDITOR
using Lean.Common;
using UnityEditor;
#endif

public class Dialogue : MonoBehaviour
{
	[SerializeField]
	[LeanTranslationDialogue]
	string dialogueID;



    public Sprite speakerFace;
	public string speakerName;

	public UnityEvent onDialogueStarted, onDialogueFinished;

	public string[] Steps { get; private set; }
	public string DialogueID => dialogueID;

	public static bool IsDialogueID(string id) => (id.Length > 3 && id[id.Length - 3] == '_');
	public static string GetDialogueSuffix(int i) => "_" + i.ToString("00");

	void Start()
	{
		PopulateSteps();
	}

	public void StartDialogue()
	{
		//DialogueUI.Instance.StartCoroutine(DialogueUI.Instance.ShowDialogueCoroutine(this));
	}

	void PopulateSteps()
	{
		int i = 0;
		string fullDialogueSeparatedBySeparator = "";
		const char AUX_SEPARATOR = '|';
		while (LeanLocalization.GetTranslationText(dialogueID + GetDialogueSuffix(i)) != null)
		{
			fullDialogueSeparatedBySeparator += LeanLocalization.GetTranslationText(dialogueID + GetDialogueSuffix(i)) + AUX_SEPARATOR;
			i++;
		}
		Steps = fullDialogueSeparatedBySeparator.Split(new char[] { AUX_SEPARATOR }, System.StringSplitOptions.RemoveEmptyEntries);
	}
}


#if UNITY_EDITOR

[CanEditMultipleObjects]
[CustomEditor(typeof(Dialogue), true)]
public class Dialogue_Inspector : LeanInspector<Dialogue>
{
	string drawed_id = string.Empty;
	public Sprite speakerFace;
	public string speakerName = string.Empty;


	public string[] steps;

	protected override void DrawInspector()
	{
		UpdateSteps();

		Draw("speakerFace", "Image to identify the speaker");
		Draw("speakerName", "Speaker's name");
		
		Draw("dialogueID", "Dialogue translation ID. Only identifiers with _00 suffix will be shown");

		EditorGUILayout.Separator();

		DrawSteps();

		EditorGUILayout.Separator();

		Draw("onDialogueStarted", "Event fired on dialogue started");
		Draw("onDialogueFinished", "Event fired on dialogue finished");

		EditorGUILayout.Separator();
		GUILayout.Label("Dialogue control:");
        if(GUILayout.Button("Next sentence"))
            GameObject.FindObjectOfType<DialogueUI>().NextStep();
        if(GUILayout.Button("Increase text speed"))
			GameObject.FindObjectOfType<DialogueUI>().IncreaseSpeed();
        if(GUILayout.Button("Reset text speed"))
			GameObject.FindObjectOfType<DialogueUI>().ResetSpeed();

	}

	void UpdateSteps()
	{
		if (tgt.DialogueID != drawed_id)
		{
			steps = GetSteps(tgt.DialogueID);
			drawed_id = tgt.DialogueID;
		}
	}

	void DrawSteps()
	{
		if (tgts.Length != 1)
			return;

		if (steps != null && steps.Length > 0)
		{
			EditorGUILayout.Separator();

			EditorGUI.BeginDisabledGroup(true);

			int i = 0;
			foreach (var step in steps)
			{
				EditorGUILayout.TextField(drawed_id + Dialogue.GetDialogueSuffix(i), step);
				i++;
			}
			EditorGUI.EndDisabledGroup();
		}

	}

	string[] GetSteps(string identifier)
	{
		int i = 0;
		string fullDialogueSeparatedBySeparator = "";
		const char AUX_SEPARATOR = '|';
		while (LeanLocalization.GetTranslationText(identifier + Dialogue.GetDialogueSuffix(i)) != null)
		{
			fullDialogueSeparatedBySeparator += LeanLocalization.GetTranslationText(identifier + Dialogue.GetDialogueSuffix(i)) + AUX_SEPARATOR;
			i++;
		}
		return fullDialogueSeparatedBySeparator.Split(new char[] { AUX_SEPARATOR }, System.StringSplitOptions.RemoveEmptyEntries);
	}
}

#endif