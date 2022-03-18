using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class SalaContiguaSceneController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _countDownText;
    DateTime _startTime;

    bool _lost;
    MovementController _player;
    [SerializeField]
    GameObject _blockStairsDialog;
    [SerializeField]
    GameObject _stairsPortal;
    [SerializeField]
    DialogueTrigger _dialogueTrigger;
    [SerializeField] GameObject _blockDomeColsed;
    int _firstTime;
    [SerializeField] DialogueTrigger _codeDialog;

    void Start()
    {
        _player = FindObjectOfType<MovementController>();
        _firstTime = PlayerPrefs.GetInt("IsContiguaFirstTime",1);

        if (!GameProgressController.IsCeilingClosed())
        {
            if (!GameProgressController.GetCountdown())
            {
                //Activo Cuenta Atrás
                GameProgressController.SetCountdownActive(true);
            }
            _startTime = GameProgressController.GetCountDownTime();
            _blockStairsDialog.SetActive(true);
            _stairsPortal.SetActive(false);
            _dialogueTrigger.gameObject.SetActive(false);
            _blockDomeColsed.SetActive(false);
        }
        else
        {
            if (GameProgressController.IsCazadoresDeFlaresSolved())
            {
                _blockDomeColsed.SetActive(false);
            }
            else
            {
                _blockDomeColsed.SetActive(true);
                _blockStairsDialog.SetActive(false);
                _stairsPortal.SetActive(true);
                _dialogueTrigger.gameObject.SetActive(true);
                
                GameEvents.ShowScreenText.Invoke("Go to the Archive and ask for help");
            }
            
        }

    }

    IEnumerator WaitDialog()
    {
        yield return new WaitForSeconds(1.5f);
        _codeDialog.triggerDialogueEvent(true);
    }

    void Update()
    {

        if (!GameProgressController.IsCeilingClosed())
        {   
            TimeSpan _span = System.DateTime.Now.Subtract(_startTime);
            int remainingSeconds = 150 - (int)_span.TotalSeconds;
            if (remainingSeconds < 0)
            {
                if (!_lost)
                {
                    _lost = true;
                    GameProgressController.SetCountdownActive(false);
                    GameProgressController.SetArrivingRoomDoor(false);

                    GameEvents.LoadScene.Invoke("Lomnicky_2_Sala llegada");
                }
                _countDownText.text = "0";
            }
            else
            {
                int minutes = remainingSeconds / 60;
                int seconds = remainingSeconds % 60;
                _countDownText.text = "<mspace=0.75em>"+ minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
        else
        {
            if (_countDownText.enabled)
            {
                _countDownText.enabled = false;
                _blockStairsDialog.SetActive(false);
                _stairsPortal.SetActive(true);
            }
        }
    }
}
