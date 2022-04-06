using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaPanelesACSceneController : MonoBehaviour
{
    MovementController player;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera _startingCamera;
    [SerializeField]
    Transform _autoPilotTarget0;
    [SerializeField] private DialogueTrigger _welcomeDialog;
    private void Awake()
    {
        if (!GameProgressController.getArrivedToPicDuMudi())
        {
            GameProgressController.SetCurrentStartPoint(0);
        }
    }
    void Start()
    {
        if (!GameProgressController.getArrivedToPicDuMudi())
        {
            player = FindObjectOfType<MovementController>();
            GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
            StartCoroutine(CrStart());
            GameProgressController.SetArrivedToPicDuMidi(true);
        }
        else
        {
            _startingCamera.m_Priority = 0;
        }
    }
    IEnumerator CrStart()
    {
        yield return new WaitForSeconds(2f);
        _startingCamera.m_Priority = 0;
        yield return new WaitForSeconds(2.5f);
        
        
        _welcomeDialog.triggerDialogueEvent(true);
        
    }
    public void EndWelcome()
    {
        CurrentSceneManager._canMove = true;
    }
}
