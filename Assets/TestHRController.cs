using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestHRController : MonoBehaviour
{
    bool _playing;
    float _totalTime;
    float _gameTime;
    [SerializeField] Image _timeBar;
    [SerializeField] TextMeshProUGUI _pressure;
    [SerializeField] Leveler[] _levelers;
    [SerializeField] RectTransform[] _markers;

    [SerializeField] Sprite[] _iceCubes;
    [SerializeField] SpriteRenderer _iceCube;
    int _step;
    bool _usingBomb;
    List<float> _values;
    List<float> _pressureChanges;
    PuzzleStatesController _mainPuzzleController;
    [SerializeField] private GameObject _outBeam;
    float _temp;
    bool _win;
    void Start()
    {
        _gameTime = 20;
        _totalTime = 20;
        _mainPuzzleController = FindObjectOfType<PuzzleStatesController>();
        _values = new List<float>();
        _values.Add(0.75f);
        _values.Add(0.5f);
        _values.Add(0.65f);
        _pressureChanges = new List<float>();
        _pressureChanges.Add(-2f);
        _pressureChanges.Add(-0.6f);
        _pressureChanges.Add(-0.2f);
        _pressureChanges.Add(-0.4f);
        _pressureChanges.Add(-0.2f);

        _temp = 3f;
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
    public void Fail()
    {
        _gameTime -= 2f;
    }
    public void Check()
    {

        _levelers[_step].Check();
        //float height = (_circles[_step].anchoredPosition.y / 400f) + 0.5f;

        //if (Mathf.Abs(_values[_step] - height) < 0.05f)
        //{
        //    _mainPuzzleController.CorrectFeedback();
        //    StartCoroutine(UpdatePressure(_pressureChanges[_step]));
        //    _step++;
        //    if (_step == 3)
        //    {
        //        _playing = false;
        //        StartCoroutine(Win());
        //    }
        //}
        //else
        //{
        //    _circles[_step].anchoredPosition = new Vector2(0, -200f);
        //    _gameTime -= 5f;
        //    _mainPuzzleController.FailFeedback();
        //}
    }
    IEnumerator Win()
    {

        yield return new WaitForSeconds(1f);
        _pressure.color = Color.green;
        yield return new WaitForSeconds(1f);
        GameProgressController.SSTVacuumSystemFixed = true;
        _mainPuzzleController.Win();
    }
    IEnumerator UpdatePressure(float _amount)
    {
        float _currentPressure = _temp;
        float _targetPressure = _temp + _amount;
        for (float i = 0; i < 0.5f; i += Time.deltaTime)
        {
            yield return null;
            _temp = _currentPressure + (_amount * (i / 0.5f));
        }
        _temp = _targetPressure;
    }
    public void StartGame()
    {
        _playing = true;
        foreach (Leveler l in _levelers)
        {
            l.Activate();
        }
    }
    public void Next()
    {
        StartCoroutine(CrNext());
        
    }
    IEnumerator CrNext()
    {
        _step++;
        Vector3 startingScale = _outBeam.transform.localScale;
        Vector3 endScale = _outBeam.transform.localScale- new Vector3(0, 0.45f, 0);
        if (_step == 6)
        {
            endScale = new Vector3(10.8130f, 0.3607f, 1f);
        }
        for (float i = 0; i< 0.25f; i += Time.deltaTime)
        {
            _outBeam.transform.localScale = Vector3.Lerp(startingScale, endScale, i/0.25f);
            yield return null;
        }
        _outBeam.transform.localScale = endScale;
        if (_step == 6)
        {
            //_outBeam.transform.position = new Vector3(5.2337f, 2.432f, -2.2356f);
            //_outBeam.transform.localScale = new Vector3(10.8130f, 0.3607f, 1f);
            StartCoroutine(End());
        }
    }
    public IEnumerator End()
    {
        _playing = false;

        yield return new WaitForSeconds(2f);
        FindObjectOfType<PuzzleStatesController>().Win();
    }
    void Update()
    {   

        //_circles[_step].anchoredPosition += new Vector2(0, 400 *Mathf.Sin(Time.deltaTime));
        //_circles[_step].anchoredPosition = new Vector2(0, Mathf.Clamp(_circles[_step].anchoredPosition.y, -200, 200));
        
        int pressureUnits = (int)_temp;
        int presureCents = (int)(_temp * 100) % 100;

        //_pressure.text = "<mspace=100>" + pressureUnits.ToString("00") + "." + presureCents.ToString("00") + "</mspace><size=50%>mbar</size>";
        if (_playing)
        {
            _gameTime -= Time.deltaTime;
            float amount = _gameTime / _totalTime;
            _timeBar.fillAmount = 1-amount;
            if(amount < 0.75f)
            {
                _iceCube.sprite = _iceCubes[1];
            }
            if(amount < 0.5f)
            {
                _iceCube.sprite = _iceCubes[2];
            }
            if(amount < 0.25f)
            {
                _iceCube.sprite = _iceCubes[3];
            }
            if (amount <= 0)
            {
                //_iceCube.sprite = _iceCubes[4];
            }
            if (_gameTime <= 0)
            {
                _playing = false;
                FindObjectOfType<PuzzleStatesController>().GameOver();
            }
        }
    }
}
