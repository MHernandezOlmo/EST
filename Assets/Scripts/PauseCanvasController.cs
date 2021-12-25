using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasController : MonoBehaviour
{
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] GameObject _solarPediaCanvas;
    [SerializeField] GameObject _settings;
    private void Start()
    {
        Time.timeScale = 1f;
        Hide();
    }
    public void Show(bool openSolarPedia)
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        if (openSolarPedia)
        {
            _solarPediaCanvas.SetActive(true);
            _pauseCanvas.SetActive(false);
        }
        else
        {
            _pauseCanvas.SetActive(true);
            _solarPediaCanvas.SetActive(false);
        }
    }

    public void Continue()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        Time.timeScale = 1;
        Hide();
    }
    public void OpenSolarpedia()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        _solarPediaCanvas.SetActive(true);
        _pauseCanvas.SetActive(false);
    }
    public void CloseSolarpedia()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        _solarPediaCanvas.SetActive(false);
        _pauseCanvas.SetActive(true);
    }

    public void OpenSettings()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        _settings.SetActive(true);
        _pauseCanvas.SetActive(false);
    }
    public void CloseSettings()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        _settings.SetActive(false);
        _pauseCanvas.SetActive(true);
    }
    public void LoadMainMenu()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.Back);
        Time.timeScale = 1;
        GameEvents.LoadScene.Invoke("MainMenu");
    }
    public void Hide()
    {
        _pauseCanvas.SetActive(false);
    }
}

