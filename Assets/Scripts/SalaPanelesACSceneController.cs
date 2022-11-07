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
    [SerializeField] private DialogueTrigger _endTrigger;
    public GameObject _closet;
    private void Awake()
    {
        if (!GameProgressController.PicDuMidiWelcome)
        {
            GameProgressController.SetCurrentStartPoint(0);
        }
        StartCoroutine(CrEnd());   
    }
    public void OpenCloset()
    {
        _closet.SetActive(true);
    }
    IEnumerator CrEnd()
    {
        if (GameProgressController.PicDuMidiPuzzleAssociation)
        {
            GameEvents.ClearMissionText.Invoke();
        }
        yield return new WaitForSeconds(1f);
        if (GameProgressController.PicDuMidiPuzzleAssociation)
        {
            _endTrigger.triggerDialogueEvent(true);
        }
    }

    public void LoadMenu()
    {
        GameProgressController.PicDuMidiSolved = true;
        PlayerPrefs.SetInt("PieceToSecure", 2);
        GameEvents.LoadScene.Invoke("SecurePiece");
    }
    void Start()
    {
        if (!GameProgressController.PicDuMidiWelcome)
        {
            player = FindObjectOfType<MovementController>();
            GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
            StartCoroutine(CrStart());
            GameProgressController.PicDuMidiWelcome = true;
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
