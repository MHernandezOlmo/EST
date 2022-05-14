using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintPuzzleController : MonoBehaviour
{
    private int _currentLevel, _currentPoints;
    private bool _underCd;
    private Coroutine _timeCr;
    private List<int> _selectedIndexes, _currentIndexes;
    [SerializeField] private GameObject _startCanvas, _gameOverCanvas;
    [SerializeField] private Image _timeBar;
    [SerializeField] private GridLayoutGroup _layout;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private int[] _buttonsAmount, _columnsAmount;
    [SerializeField] private int[] _whiteBlocksAmount;
    [SerializeField] private float[] _times;

    private void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].onClick.AddListener(() => UseButton(i));
        }
    }

    public void RestartGame()
    {
        _startCanvas.SetActive(false);
        _currentLevel = -1;
        PlayLevel();
    }

    public void PlayLevel()
    {
        _currentLevel++;
        if (_currentLevel >= _buttonsAmount.Length)
        {
            if (_timeCr != null)
            {
                StopCoroutine(_timeCr);
            }
            print("Winwin");
        }
        else
        {
            _timeBar.fillAmount = 1f;
            _layout.constraintCount = _columnsAmount[_currentLevel];
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (i < _buttonsAmount[_currentLevel])
                {
                    _buttons[i].gameObject.SetActive(true);
                }
                else
                {
                    _buttons[i].gameObject.SetActive(false);
                }
                _buttons[i].GetComponent<Image>().enabled = true;
            }
        }
        _currentPoints = 0;
        StartCoroutine(CrRandomPuzzle());
    }

    IEnumerator CrRestTime(float levelTime)
    {
        for (float i = levelTime; i > 0; i-= Time.deltaTime)
        {
            _timeBar.fillAmount = i / levelTime;
            yield return null;
        }
        //Pierde
        _gameOverCanvas.SetActive(true);
        _timeBar.fillAmount = 0;
    }

    public void UseButton(int buttonIndex)
    {
        if (!_underCd)
        {
            if (_selectedIndexes.Contains(buttonIndex))
            {
                _currentPoints ++;
                _buttons[buttonIndex].GetComponent<Image>().enabled = false;
                if(_currentPoints >= _whiteBlocksAmount[_currentLevel])
                {
                    PlayLevel();
                }
            }
            else
            {
                StopCoroutine(_timeCr);
                _gameOverCanvas.SetActive(true);
            }
        }
    }

    IEnumerator CrRandomPuzzle()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Image>().color = Color.gray;
        }
        _underCd = true;
        yield return new WaitForSeconds(1f);
        _underCd = false;
        _selectedIndexes = new List<int>();
        _currentIndexes = new List<int>();
        for (int i = 0; i < _buttonsAmount[_currentLevel]; i++)
        {
            _currentIndexes.Add(i);
        }

        for (int i = 0; i < _whiteBlocksAmount[_currentLevel]; i++)
        {
            int selected = Random.Range(0, _currentIndexes.Count);
            _selectedIndexes.Add(_currentIndexes[selected]);
            _currentIndexes.RemoveAt(selected);
        }

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Image>().color = Color.black;
        }
        for (int i = 0; i < _selectedIndexes.Count; i++)
        {
            _buttons[_selectedIndexes[i]].GetComponent<Image>().color = Color.white;
        }

        if (_timeCr != null)
        {
            StopCoroutine(_timeCr);
        }
        _timeCr = StartCoroutine(CrRestTime(_times[_currentLevel]));
    }
}
