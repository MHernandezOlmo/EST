using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStates { Exploration, Pause, Dialogue, Puzzle, Combat, Cinematic};

public class CurrentSceneManager : MonoBehaviour
{
    public static GameStates _state;
    public static bool _canMove;
    public static bool _canSpin;
    public static bool _canShield;
    public static float _elapsedSceneTime;
    public static GameStates _prePause;
    public static bool CanDash;
    public static float _walkSpeed;
    public static bool _skillEnabled;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isExterior;
    public static bool _canJetpack;
    public static bool _isJetpacking;
    private void Awake()
    {
        _elapsedSceneTime = 0;
        _canMove = false;
        _canShield = true;
        _canSpin = true;
        _canJetpack = true;
        GameEvents.ChangeGameState.AddListener(SetGameState);
        if (_speed == 0)
        {
            _speed = 0.8f; //Default Speed
        }
        SetWalkSpeed(_speed);
    }

    public static void SetWalkSpeed(float walkSpeed)
    {
        PlayerPrefs.SetFloat("WalkSpeed", walkSpeed);
        _walkSpeed = PlayerPrefs.GetFloat("WalkSpeed");
    }
    public static float GetWalkSpeed()
    {
        return _walkSpeed;
    }

    void Start()
    {
        _state = GameStates.Exploration;
        _canMove = true;
    }

    public static void UnPause()
    {
        _state = _prePause;
    }

    public static void SetGameState(GameStates newState)
    {
        if(newState== GameStates.Pause)
        {
            _prePause = _state;
        }
        _state = newState;
        if (newState != GameStates.Pause)
        {
            Time.timeScale = 1f;
        }
        switch (newState)
        {
            case GameStates.Exploration:
                FindObjectOfType<MovementController>().autopilot = null;
                FindObjectOfType<MovementController>().EnableMovement();
                break;
            case GameStates.Pause:
                Time.timeScale = 0;
                FindObjectOfType<PauseCanvasController>().Show(false);
                break;
        }
    }

    public bool IsExterior
    {
        get
        {
            return _isExterior;
        }
    }

    private void Update()
    {
        _elapsedSceneTime += Time.deltaTime;
    }
}
