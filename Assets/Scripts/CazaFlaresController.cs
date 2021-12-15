using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CazaFlaresController : MonoBehaviour
{
    private bool _gameStarted;
    [SerializeField] private float _totalGameTime;
    private float _gameTime;
    [SerializeField] private LoopsBehaviour[] _loops;
    [SerializeField] private FilamentsBehaviour[] _filaments;
    [SerializeField] private Image _timeBarImage;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private FlareBehaviour[] _flares;
    [SerializeField] private TextMeshProUGUI _feedbackText;
    private int _correctCounter;


    public void StartGame()
    {
        _gameStarted = true;
        _gameTime = _totalGameTime;

        StartCoroutine(CrPlayEvents());
    }

    IEnumerator CrPlayEvents()
    {
        yield return new WaitForSeconds(1f);
        _loops[1].Play();
        yield return new WaitForSeconds(1f);
        _filaments[0].Play();
        yield return new WaitForSeconds(1f);
        _loops[4].Play();
        yield return new WaitForSeconds(1f);
        _loops[5].Play();
        yield return new WaitForSeconds(1f);
        _loops[8].Play();
        yield return new WaitForSeconds(1f);
        _flares[1].Play();
        yield return new WaitForSeconds(1f);
        _loops[9].Play();
        yield return new WaitForSeconds(1f);
        _flares[8].Play();
        yield return new WaitForSeconds(1f);
        _flares[16].Play();
        yield return new WaitForSeconds(1f);
        _flares[9].Play();
        yield return new WaitForSeconds(1f);
        _flares[12].Play();
        yield return new WaitForSeconds(1f);
        _filaments[9].Play();
        yield return new WaitForSeconds(1f);
        _filaments[10].Play();
        yield return new WaitForSeconds(1f);
        _filaments[1].Play();
        yield return new WaitForSeconds(1f);
        _flares[6].Play();
        yield return new WaitForSeconds(1f);
        _flares[2].Play();
        yield return new WaitForSeconds(1f);
        _flares[3].Play();
        yield return new WaitForSeconds(1f);
        _filaments[2].Play();
        yield return new WaitForSeconds(1f);
        _flares[4].Play();
        yield return new WaitForSeconds(1f);
        _flares[5].Play();
        yield return new WaitForSeconds(1f);
        _loops[10].Play();
        yield return new WaitForSeconds(1f);
        _filaments[3].Play();
        yield return new WaitForSeconds(1f);
        _filaments[4].Play();
        yield return new WaitForSeconds(1f);
        _flares[10].Play();
        yield return new WaitForSeconds(1f);
        _flares[11].Play();
        yield return new WaitForSeconds(1f);
        _flares[13].Play();
        yield return new WaitForSeconds(1f);
        _filaments[7].Play();
        yield return new WaitForSeconds(1f);
        _filaments[8].Play();
        yield return new WaitForSeconds(1f);
        _loops[11].Play();
        yield return new WaitForSeconds(1f);
        _flares[14].Play();
        yield return new WaitForSeconds(1f);
        _flares[17].Play();
        yield return new WaitForSeconds(1f);
        _loops[7].Play();
        yield return new WaitForSeconds(1f);
        _flares[15].Play();
        yield return new WaitForSeconds(1f);
        _loops[3].Play();
        yield return new WaitForSeconds(1f);
        _filaments[5].Play();
        yield return new WaitForSeconds(1f);
        _filaments[6].Play();
        yield return new WaitForSeconds(1f);
        _flares[1].Play();
        yield return new WaitForSeconds(1f);
        _flares[19].Play();
        yield return new WaitForSeconds(1f);
        _filaments[1].Play();
        yield return new WaitForSeconds(1f);
        _loops[2].Play();
        yield return new WaitForSeconds(1f);
        _loops[0].Play();
        yield return new WaitForSeconds(1f);
        _flares[0].Play();
        yield return new WaitForSeconds(1f);
        _loops[6].Play();
        yield return new WaitForSeconds(1f);
        _flares[7].Play();
    }
    public void NotifyLoop()
    {
        StartCoroutine(FeedbackAnimate("LOOP"));
        _gameTime -= 2f;
    }
    public void NotifyFilament()
    {
        StartCoroutine(FeedbackAnimate("FILAMENT"));
        _gameTime -= 2f;
    }

    public IEnumerator FeedbackAnimate(string eventName)
    {
        RectTransform rt = _feedbackText.rectTransform;
        _feedbackText.text = eventName;
        _feedbackText.color = Color.red;
        if(_feedbackText.text == "FLARE")
        {
            _feedbackText.color = Color.green;
        }

        for(float i = 0; i< 0.25f; i += Time.deltaTime)
        {
            rt.localScale = Vector3.one*i*4;
            yield return null;
        }
        yield return new WaitForSeconds(0.25f);
        rt.localScale = Vector3.zero;
    }


    public void NotifyHunt()
    {
        StartCoroutine(FeedbackAnimate("FLARE"));
        _correctCounter++;
        _text.text = $"Captured Flares\n {_correctCounter}/20";
        if (_correctCounter >= 20)
        {
            GameProgressController.SetCazadoresDeFlaresSolved(true);
            FindObjectOfType<PuzzleStatesController>().Win();
        }
    }
    void Update()
    {
        if (_gameStarted)
        {
            _gameTime -= Time.deltaTime;
            _timeBarImage.fillAmount = _gameTime / _totalGameTime;
            if (_gameTime < 0)
            {
                _gameStarted = false;
                
                FindObjectOfType<PuzzleStatesController>().GameOver();
            }
        }
    }
}
