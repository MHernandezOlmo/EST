using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleStatesController : MonoBehaviour
{
    [SerializeField] RectTransform _holder;
    [SerializeField] RectTransform _gameOverholder;
    [SerializeField] RectTransform _winholder;
    [SerializeField] AnimationCurve _animationCurve;
    [SerializeField] Image _failImage;
    [SerializeField] Color _failColor, _failColorTransparent, _correctColor, _correctColorTransparent;
    [SerializeField] AnimationCurve _failAnimationCurve;
    public void StartPuzzle()
    {
        StartCoroutine(CrStartPuzzle());
    }
    public void Start()
    {
        if (PlayerPrefs.GetInt("NoInstructions") == 1)
        {
            PlayerPrefs.SetInt("NoInstructions", 0);
            switch (SceneManager.GetActiveScene().name)
            {
                case "Manchas":
                    FindObjectOfType<Roulette>().StartGame();
                    break;
                case "Parejas":
                    FindObjectOfType<OpticaAdaptativaController>().StartPlaying();
                    break;
                case "CazaFlares":
                    FindObjectOfType<CazaFlaresController>().StartGame();
                    break;
                case "Coronografo":
                    FindObjectOfType<CoronografoController>().StartGame();
                    break;
            }
            StartCoroutine(CrStartPuzzle());
        }
    }
    public void GameOver()
    {
        StartCoroutine(ShowGameOverCanvas());
    }
    public void Win()
    {
        StartCoroutine(ShowWinCanvas());
    }
    public void Back()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Manchas":
                GameEvents.LoadScene.Invoke("Lomnicky_11_Sala Cupula");
                break;
            case "CazaFlares":
                GameEvents.LoadScene.Invoke("SST_4_sala_observacion Lomnicky");
                break;
            case "Parejas":
                GameEvents.LoadScene.Invoke("PicDuMidi_14_Sala b");
                break;
            case "Coronografo":
                GameEvents.LoadScene.Invoke("PicDuMidi_9_paneles_d");
                break;
        }
    }
    public void Restart()
    {
        GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
    }
    public void RestartNoInstructions()
    {
        PlayerPrefs.SetInt("NoInstructions", 1);
        GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
    }
    IEnumerator ShowWinCanvas()
    {
        for (float i = 0; i < 2f; i += Time.deltaTime)
        {
            _winholder.anchoredPosition = Vector3.Lerp(new Vector3(0, 1100, 0), Vector3.zero, _animationCurve.Evaluate(i / 2f));
            yield return null;
        }
        _winholder.anchoredPosition = new Vector3(0, 0, 0);
    }
    IEnumerator ShowGameOverCanvas()
    {
        for (float i = 0; i < 2f; i += Time.deltaTime)
        {
            _gameOverholder.anchoredPosition = Vector3.Lerp(new Vector3(0, 1100, 0), Vector3.zero,  _animationCurve.Evaluate(i / 2f));
            yield return null;
        }
        _gameOverholder.anchoredPosition = new Vector3(0, 0, 0);
    }
    IEnumerator CrStartPuzzle()
    {
        for(float i = 0; i< 2f; i += Time.deltaTime)
        {
            _holder.anchoredPosition = Vector3.Lerp(Vector3.zero, new Vector3(0, 1100, 0),_animationCurve.Evaluate(i / 2f));
            yield return null;
        }
        _holder.anchoredPosition = new Vector3(0, 1100, 0);
    }

    public void CorrectFeedback()
    {
        StartCoroutine(CrCorrect());
    }
    public void FailFeedback()
    {
        StartCoroutine(CrFail());
    }
    IEnumerator CrCorrect()
    {
        float correctFeedbackTime = 0.5f;
        for (float i = 0; i < correctFeedbackTime; i += Time.deltaTime)
        {
            _failImage.color = Color.Lerp(_correctColorTransparent, _correctColor, _failAnimationCurve.Evaluate(i / correctFeedbackTime));
            yield return null;
        }
        _failImage.color = _correctColorTransparent;
    }
    IEnumerator CrFail()
    {
        float failFeedbackTime = 0.5f;
        for(float i =0; i<failFeedbackTime; i += Time.deltaTime)
        {
            _failImage.color = Color.Lerp(_failColorTransparent, _failColor,_failAnimationCurve.Evaluate(i/failFeedbackTime));
            yield return null;
        }
        _failImage.color = _failColorTransparent;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Win();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameOver();
        }
    }
}
