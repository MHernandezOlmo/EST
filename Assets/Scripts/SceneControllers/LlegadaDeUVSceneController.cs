using System.Collections;
using System.Collections.Generic;
using Lean.Localization;
using UnityEngine;

public class LlegadaDeUVSceneController : MonoBehaviour
{
    MovementController _player;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera _startingCamera;

    [SerializeField]
    Transform _autoPilotTarget0;
    bool endedDialog;
    void Start()
    {
        _player = FindObjectOfType<MovementController>();
        //_player.autopilot = new Vector3(2.7f, 0.7f, -1.67f);
        GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
        StartCoroutine(CrStart());
    }
    IEnumerator CrStart()
    {
        yield return new WaitForSeconds(2f);
        _startingCamera.m_Priority = 0;
        yield return new WaitForSeconds(2.5f);
        CurrentSceneManager._canMove = true;
        _player.autopilot = _autoPilotTarget0.position;
        yield return new WaitForSeconds(3f);
        while(CurrentSceneManager._state!= GameStates.Exploration)
        {
            yield return null;
        }

        
        GameEvents.ShowScreenText.Invoke("Go to the cableway.");
        //GameEvents.ShowScreenText.Invoke(LeanLocalization.GetTranslationText("UI/ExitMenu"));

    }
    void Update()
    {
        
    }
}
