using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using Lean.Localization;

public class SalaContiguaSceneController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _countDownText;
    float _startTime;

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

    IEnumerator Start()
    {
        _player = FindObjectOfType<MovementController>();
        _firstTime = PlayerPrefs.GetInt("IsContiguaFirstTime",1);

        if (!GameProgressController.LomnickyClosedCeiling)
        {
            if (!GameProgressController.LomnickyCountdown)
            {
                //Activo Cuenta Atrás
                GameProgressController.LomnickyCountdown =true;
            }
            _startTime = GameProgressController.LomnickyCountdownTime;
            _blockStairsDialog.SetActive(true);
            _stairsPortal.SetActive(false);
            _dialogueTrigger.gameObject.SetActive(false);
            _blockDomeColsed.SetActive(false);
        }
        else
        {
            if (GameProgressController.LomnickyPuzzleFlareHunters)
            {
                _blockDomeColsed.SetActive(false);
            }
            else
            {
                _blockDomeColsed.SetActive(true);
                _blockStairsDialog.SetActive(false);
                _stairsPortal.SetActive(true);
                _dialogueTrigger.gameObject.SetActive(true);
                yield return null;
            }
        }
    }

    public void ShowAlert()
    {
        GameEvents.ShowScreenText.Invoke("Go to the communications room and call Eclipse!");
    }

    IEnumerator WaitDialog()
    {
        yield return new WaitForSeconds(1.5f);
        _codeDialog.triggerDialogueEvent(true);
    }

    void Update()
    {

        if (!GameProgressController.LomnickyClosedCeiling)
        {
            GameProgressController.LomnickyCountdownTime += Time.deltaTime;
            int remainingSeconds =(int)(150 - GameProgressController.LomnickyCountdownTime);
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
