using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaintPuzzleController : MonoBehaviour
{
    private int _currentLevel, _currentPoints;
    private bool _underCd, _miniCD;
    private Coroutine _timeCr;
    private List<int> _selectedIndexes, _currentIndexes;
    [SerializeField] private Color _blackColor;
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private TextMeshProUGUI _countDownTx;
    [SerializeField] private PuzzleStatesController _puzzleStatesController;
    [SerializeField] private Image _timeBar, _fillTower;
    [SerializeField] private GridLayoutGroup _layout;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private int[] _buttonsAmount, _columnsAmount;
    [SerializeField] private int[] _whiteBlocksAmount;
    [SerializeField] private float[] _times;
    private float levelPercent;

    private void Start()
    {
        levelPercent = 1f / _buttonsAmount.Length;
        for (int i = 0; i < _buttons.Length; i++)
        {
            int aux = i;
            _buttons[aux].onClick.AddListener(() => UseButton(aux));
        }
    }

    public void StartGame()
    {
        StartCoroutine(CrFirstDelay());
        IEnumerator CrFirstDelay()
        {
            _loadingPanel.SetActive(true);
            _countDownTx.text = "";
            yield return new WaitForSeconds(1f);
            _currentLevel = -1;
            PlayLevel();
        }
    }

    public void PlayLevel()
    {
        _currentLevel++;
        _fillTower.fillAmount = levelPercent * _currentLevel;
        if (_timeCr != null)
        {
            StopCoroutine(_timeCr);
        }
        if (_currentLevel >= _buttonsAmount.Length)
        {
            _puzzleStatesController.Win();
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
            _currentPoints = 0;
            StartCoroutine(CrRandomPuzzle());
        }
    }

    IEnumerator CrRestTime(float levelTime)
    {
        for (float i = levelTime; i > 0; i-= Time.deltaTime)
        {
            _timeBar.fillAmount = i / levelTime;
            yield return null;
        }
        _puzzleStatesController.GameOver();
        _timeBar.fillAmount = 0;
    }

    public void UseButton(int buttonIndex)
    {
        if (!_underCd && !_miniCD)
        {
            StartCoroutine(CrMiniCD());
            if (_selectedIndexes.Contains(buttonIndex))
            {
                _currentPoints ++;
                _fillTower.fillAmount = levelPercent * _currentLevel + (levelPercent * ((float)_currentPoints/ _whiteBlocksAmount[_currentLevel]));
                _buttons[buttonIndex].GetComponent<Image>().enabled = false;
                if(_currentPoints >= _whiteBlocksAmount[_currentLevel])
                {
                    PlayLevel();
                }
            }
            else
            {
                StopCoroutine(_timeCr);
                _puzzleStatesController.GameOver();
            }
        }
    }

    IEnumerator CrMiniCD()
    {
        _miniCD = true;
        yield return null;
        _miniCD = false;
    }

    IEnumerator CrRandomPuzzle()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Image>().color = _blackColor;
        }
        _underCd = true;
        _loadingPanel.SetActive(true);
        _countDownTx.text = "3";
        yield return new WaitForSeconds(1f);
        _countDownTx.text = "2";
        yield return new WaitForSeconds(1f);
        _countDownTx.text = "1";
        yield return new WaitForSeconds(1f);
        _loadingPanel.SetActive(false);
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
            _buttons[i].GetComponent<Image>().color = _blackColor;
        }
        string res = "";
        for (int i = 0; i < _selectedIndexes.Count; i++)
        {
            res += _selectedIndexes[i].ToString() + " | ";
            _buttons[_selectedIndexes[i]].GetComponent<Image>().color = Color.white;
        }

        if (_timeCr != null)
        {
            StopCoroutine(_timeCr);
        }
        _timeCr = StartCoroutine(CrRestTime(_times[_currentLevel]));
    }
}
