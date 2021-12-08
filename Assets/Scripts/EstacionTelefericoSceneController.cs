using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacionTelefericoSceneController : MonoBehaviour
{
    MovementController _player;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera _firstCamera;
    [SerializeField]
    Transform _autoPilotTarget0;
    [SerializeField] GameObject _combatCanvas;
    [SerializeField] GameObject _dialog;
    [SerializeField] GameObject _end;
    void Start()
    {
        _player = FindObjectOfType<MovementController>();

        if (!GameProgressController.IsCazadoresDeFlaresSolved())
        {
            GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
            StartCoroutine(CrInitialCinematic());
            _dialog.SetActive(true);
            _end.SetActive(false);
        }
        else
        {
            _firstCamera.Priority = 0;
            if (GameProgressController.IsChoosePhenomenomSolved())
            {
                _dialog.SetActive(false);
                _end.SetActive(true);
            }
        }
    }

    IEnumerator CrInitialCinematic()
    {
        CurrentSceneManager._canMove = true;
        yield return new WaitForSeconds(2);
        _player.autopilot = _autoPilotTarget0.position;
        yield return new WaitForSeconds(2);

    }

    public void ChangeCameraPriority()
    {
        
        _firstCamera.Priority = 0;

        
    }

}
