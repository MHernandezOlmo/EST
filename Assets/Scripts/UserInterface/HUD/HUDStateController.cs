using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HUDState
{
	Exploration = 1 << 0,
	Pause = 1 << 1,
	Dialogue = 1 << 2,
	Puzzle = 1 << 3,
	Combat = 1 << 4,
}

public class HUDStateController : MonoBehaviour
{
	const HUDState DEFAULT_STATE = HUDState.Exploration;

	public HUDState CurrentState { get; private set; } = DEFAULT_STATE;

    public void OnEnable() => GameEvents.CombatEvent.AddListener(CombatEventCallback);

    public void CombatEventCallback(bool state)
    {
        if (state == true)
        {
            this.CurrentState = HUDState.Combat;
        }
        else
        {
            this.CurrentState = HUDState.Exploration;
        }
    }

	// --- Methods for testing purposes on editor ---

	[ContextMenu("Simulate Exploration")]
	void SetExploration()
	{
		CurrentState = HUDState.Exploration;
	}

	[ContextMenu("Simulate Combat")]
	void SetCombat()
	{
		CurrentState = HUDState.Combat;
	}

	[ContextMenu("Simulate Puzzle")]
	void SetPuzzle()
	{
		CurrentState = HUDState.Puzzle;
	}

	[ContextMenu("Simulate Dialogue")]
	void SetDialogue()
	{
		CurrentState = HUDState.Dialogue;
	}

	[ContextMenu("Simulate Pause")]
	void SetPause()
	{
		CurrentState = HUDState.Pause;
	}
}
