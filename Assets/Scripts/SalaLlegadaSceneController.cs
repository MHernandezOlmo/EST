using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class SalaLlegadaSceneController : MonoBehaviour
{
    MovementController _player;

    DateTime _startTime;
    [SerializeField]
    TextMeshProUGUI _countDownText;
    bool _lost;
    void Start()
    {
        _player = FindObjectOfType<MovementController>();
        GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
        if (!GameProgressController.IsCeilingClosed())
        {
            if (!GameProgressController.GetCountdown())
            {
                //Activo Cuenta Atrás
                GameProgressController.SetCountdownActive(true);
            }
            _startTime = GameProgressController.GetCountDownTime();
        }
        
    }
    private void Update()
    {
        if (!GameProgressController.IsCeilingClosed())
        {
            TimeSpan _span = System.DateTime.Now.Subtract(_startTime);
            int remainingSeconds = 150 - _span.Seconds;
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
                _countDownText.text = "<mspace=0.75em>"+minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }
        else
        {
            if (_countDownText.enabled)
            {
                _countDownText.enabled = false;
            }
        }
        
    }
}
