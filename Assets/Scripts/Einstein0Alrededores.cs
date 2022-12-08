using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Einstein0Alrededores : MonoBehaviour
{
    MovementController _player;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera _startingCamera;

    [SerializeField]
    Transform _autoPilotTarget0;
    [SerializeField]  DialogueTrigger _trigger;
    [SerializeField]  DialogueTrigger _secondTrigger;
    [SerializeField] GameObject[] _fakeTv;
    [SerializeField] GameObject[] _realTV;
    [SerializeField] GameObject _outsideCollider;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera vCam;
    [SerializeField] private GameObject _skillLockCollider;
    private int _remainingKills;

    public void KillTV() 
    {
        _remainingKills--;
        if (_remainingKills <= 0)
        {
            PlayerPrefs.SetInt("PieceToSecure", 2);
            GameEvents.LoadScene.Invoke("SecurePiece");
        }
    }
    public void DisableCombatCollider()
    {
        _outsideCollider.gameObject.SetActive(false);
    }
    public void DisableCollider()
    {
        _skillLockCollider.gameObject.SetActive(false);
    }
    public void ShowSkillAdvice()
    {
        GameEvents.ShowScreenText.Invoke("Obtained: Coronal Mass Ejection Skill");
    }

    void Start()
    {
        _remainingKills = 6;
        if (!GameProgressController.EinsteinUsedPrism)
        {
            _player = FindObjectOfType<MovementController>();
            if (!GameProgressController.EinsteinOpenBarrier)
            {
                //_player.autopilot = new Vector3(2.7f, 0.7f, -1.67f);
                GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
                StartCoroutine(CrStart());
            }
            else
            {
                _startingCamera.m_Priority = 0;
                CurrentSceneManager._canMove = true;
            }
        }
        else
        {
            vCam.Priority = 0;
            _secondTrigger.gameObject.SetActive( false);
            foreach(GameObject g in _fakeTv)
            {
                g.SetActive(false);
            }
            foreach (GameObject g in _realTV)
            {
                g.SetActive(true);
            }
            _outsideCollider.SetActive(true);
        }

    }
    IEnumerator CrStart()
    {
        yield return new WaitForSeconds(2f);
        _startingCamera.m_Priority = 0;
        yield return new WaitForSeconds(2.5f);
        CurrentSceneManager._canMove = true;
        _trigger.triggerDialogueEvent();
        yield return new WaitForSeconds(3f);
        while (CurrentSceneManager._state != GameStates.Exploration)
        {
            yield return null;
        }
        GameEvents.ShowScreenText.Invoke("Get the spectropolarimeter");
    }
}
