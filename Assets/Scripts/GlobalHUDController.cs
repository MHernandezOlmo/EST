using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHUDController : MonoBehaviour
{

    DialogueCanvasController _dialogueCanvasController;
    InputCanvasController _inputCanvasController;
    PauseCanvasController _pauseCanvasController;
    CinematicCanvasController _cinematicCanvasController;
    CombatCanvasController _combatCanvasController;

    private void Awake()
    {
        GameEvents.ChangeGameState.AddListener(AdaptHUD);
        _dialogueCanvasController = FindObjectOfType<DialogueCanvasController>();
        _inputCanvasController = FindObjectOfType<InputCanvasController>();
        _pauseCanvasController = FindObjectOfType<PauseCanvasController>();
        _cinematicCanvasController = FindObjectOfType<CinematicCanvasController>();
        _combatCanvasController = FindObjectOfType<CombatCanvasController>();
    }
    
    void AdaptHUD(GameStates newState)
    {
        _dialogueCanvasController.Hide();
        _inputCanvasController.Hide();
        _pauseCanvasController.Hide();
        _combatCanvasController.Hide();
        _cinematicCanvasController.Hide();
        switch (newState)
        {
            case GameStates.Combat:
                _inputCanvasController.Show();
                _combatCanvasController.Show();
                break;

            case GameStates.Dialogue:
                CurrentSceneManager._canMove = false;
                _dialogueCanvasController.Show();
                break;

            case GameStates.Exploration:
                CurrentSceneManager._canMove = true;
                _inputCanvasController.Show();
                break;
            case GameStates.Pause:
                _pauseCanvasController.Show(false);
                break;

            case GameStates.Puzzle:
                print("Paso a la puzzlecizacion");
                break;

            case GameStates.Cinematic:
                CurrentSceneManager._canMove = false;
                _cinematicCanvasController.Show();
                break;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {

    }
}
