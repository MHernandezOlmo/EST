using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class SalaLlegadaSceneController : MonoBehaviour
{
    MovementController _player;

    float _startTime;
    [SerializeField]
    TextMeshProUGUI _countDownText;
    bool _lost;
    void Start()
    {
        _player = FindObjectOfType<MovementController>();
        GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
        if (!GameProgressController.LomnickyClosedCeiling)
        {
            if (!GameProgressController.LomnickyCountdown)
            {
                //Activo Cuenta Atrás
                GameProgressController.LomnickyCountdown = true;
            }
            _startTime = GameProgressController.LomnickyCountdownTime;
        }
        
    }
    private void Update()
    {
        if (!GameProgressController.LomnickyClosedCeiling)
        {
            GameProgressController.LomnickyCountdownTime += Time.deltaTime;
            int remainingSeconds = (int)(150 - GameProgressController.LomnickyCountdownTime);
            if (remainingSeconds < 0)
            {
                if (!_lost)
                {
                    _lost = true;
                    GameProgressController.LomnickyCountdown =false;
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
