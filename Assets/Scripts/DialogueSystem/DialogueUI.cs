using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// SINGLETON? CONECTAR MEDIANTE DIALOGUEMANAGER?
public class DialogueUI : MonoBehaviour
{
	public static DialogueUI Instance;
	bool currentlyRunning;
	TextMeshProUGUI textMesh;
	int step = 0;
	int c = 0;
	float charInterval = 0.05f;
	Image speakerFace;
    TextMeshProUGUI speakerName;
	bool canMoveNext;

	private void Awake()
	{
		if (Instance == null)
		{
			if (gameObject.transform.parent == null) DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		textMesh = GetComponentInChildren<TextMeshProUGUI>();
		textMesh.gameObject.SetActive(false);
		speakerFace = transform.Find("Image Container").Find("Character Face").GetComponent<Image>();
		speakerName = transform.Find("Character Name").GetComponent<TextMeshProUGUI>();
	}

	public IEnumerator ShowDialogueCoroutine(Dialogue dialogue)
	{
		while (currentlyRunning) yield return null;

        currentlyRunning = true;
		dialogue.onDialogueStarted?.Invoke();

		textMesh.gameObject.SetActive(true);
        textMesh.text = "";

		//speakerName.text = dialogue.speakerName;
		//if (dialogue.speakerFace) speakerFace.sprite = dialogue.speakerFace;

        step = 0;
		canMoveNext = false;
        print(dialogue.Steps.Length);
        while (step < dialogue.Steps.Length)
		{
			// ir mostrando letritas actuales, recibiendo input del usuario para mostrarlas más rápidas
			// cuando las letritas lleguen al final, mostrar el triangulito de siguiente
			// con el triangulito de siguiente mostrado, si vuelve a pulsar, step++
			// si step == Length, se saldrá del bucle antes de la siguiente iteración
			while (c < dialogue.Steps[step].Length)
			{
				textMesh.text = string.Concat(textMesh.text, dialogue.Steps[step][c]);
				yield return new WaitForSeconds(charInterval);
				c++;
			}
			canMoveNext = true;

			yield return new WaitForSeconds(0.05f);
		}

		currentlyRunning = false;
		dialogue.onDialogueFinished?.Invoke();
		textMesh.gameObject.SetActive(false);

        GameEvents.eDialogue.Invoke(false);
    }

    public void NextStep()
	{
		if (canMoveNext)
		{
			step++;
			textMesh.text = String.Empty;
			c = 0;
			canMoveNext = false;
		}
	}

	public void IncreaseSpeed()
	{
		charInterval = 0.01f;
	}
	public void ResetSpeed()
	{
		charInterval = 0.05f;
	}
}
