using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombaVacioController : MonoBehaviour
{
    bool _playing;
    float _totalTime;
    float _gameTime;
    [SerializeField] Image _timeBar;
    [SerializeField] TextMeshProUGUI _pressure;
    [SerializeField] RectTransform[] _circles;
    [SerializeField] RectTransform[] _markers;
    int _step;
    bool _usingBomb;
    List<float> _values;
    List<float> _pressureChanges;
    PuzzleStatesController _mainPuzzleController;
    float _pressureValue;
    
    void Start()
    {
        _gameTime = 30;
        _totalTime = 30;
        _mainPuzzleController = FindObjectOfType<PuzzleStatesController>();
        _values = new List<float>();
        _values.Add(0.75f);
        _values.Add(0.5f);
        _values.Add(0.65f);
        _pressureChanges= new List<float>();
        _pressureChanges.Add(-2f);
        _pressureChanges.Add(-0.6f);
        _pressureChanges.Add(-0.2f);
        _pressureValue = 3f;
    }

    public void StartPressure()
    {
        _usingBomb = true;
        _markers[_step].gameObject.SetActive(false);
    }

    public void StopPressure()
    {
        if (_usingBomb)
        {
            _markers[_step].gameObject.SetActive(true);
            _usingBomb = false;
            Check();
        }
    }
    public void Check()
    {
        float height = (_circles[_step].anchoredPosition.y/400f)+0.5f;

        if (Mathf.Abs(_values[_step] - height) < 0.05f)
        {
            _mainPuzzleController.CorrectFeedback();
            StartCoroutine(UpdatePressure(_pressureChanges[_step]));
            _step++;
            if (_step == 3)
            {
                _playing = false;
                StartCoroutine(Win());
            }
        }
        else
        {
            _circles[_step].anchoredPosition = new Vector2(0, -200f);
            _gameTime -= 5f;
            _mainPuzzleController.FailFeedback();
        }
    }
    IEnumerator Win()
    {
        
        yield return new WaitForSeconds(1f);
        _pressure.color = Color.green;
        yield return new WaitForSeconds(1f);
        GameProgressController.SSTVacuumSystemFixed =true;
        _mainPuzzleController.Win();
    }
    IEnumerator UpdatePressure(float _amount)
    {
        float _currentPressure= _pressureValue;
        float _targetPressure = _pressureValue+_amount;
        for(float i = 0; i< 0.5f; i+=Time.deltaTime)
        {
            yield return null;
            _pressureValue = _currentPressure + (_amount * (i / 0.5f));
        }
        _pressureValue = _targetPressure;
    }
    public void StartGame()
    {
        _playing = true;
    }
    void Update()
    {
        if (_usingBomb)
        {
            _circles[_step].anchoredPosition += new Vector2(0, 400 * Time.deltaTime);
            _circles[_step].anchoredPosition = new Vector2(0,Mathf.Clamp(_circles[_step].anchoredPosition.y, -200, 200));
        }
        int pressureUnits = (int)_pressureValue;
        int presureCents = (int)(_pressureValue*100)%100;

        _pressure.text = "<mspace=100>" + pressureUnits.ToString("00")+"." + presureCents.ToString("00") + "</mspace><size=50%>mbar</size>";
        if (_playing)
        {
            _gameTime -= Time.deltaTime;
            _timeBar.fillAmount = _gameTime / _totalTime;
            if (_gameTime <= 0)
            {
                _playing = false;
                FindObjectOfType<PuzzleStatesController>().GameOver();
            }
        }
    }
}
