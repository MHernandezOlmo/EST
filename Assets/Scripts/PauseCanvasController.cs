using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasController : MonoBehaviour
{
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] GameObject _solarPediaCanvas;
    private void Start()
    {
        Time.timeScale = 1f;
        Hide();
    }
    public void Show(bool openSolarPedia)
    {
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
        Time.timeScale = 1;
        Hide();
    }
    public void OpenSolarpedia()
    {
        _solarPediaCanvas.SetActive(true);
        _pauseCanvas.SetActive(false);
    }
    public void CloseSolarpedia()
    {
        _solarPediaCanvas.SetActive(false);
        _pauseCanvas.SetActive(true);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        GameEvents.LoadScene.Invoke("MainMenu");
    }
    public void Hide()
    {
        _pauseCanvas.SetActive(false);
    }
}

