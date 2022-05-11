using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintPuzzleController : MonoBehaviour
{
    private int _currentLevel;
    private bool _underCd;
    private Coroutine _timeCr;
    [SerializeField] private GameObject _startCanvas, _gameOverCanvas;
    [SerializeField] private Image _timeBar;
    [SerializeField] private GridLayoutGroup _layout;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private int[] _buttonsAmount, _columnsAmount;
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
        if (_currentLevel >= 3)
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
            }
            if (_timeCr != null)
            {
                StopCoroutine(_timeCr);
            }
            _timeCr = StartCoroutine(CrRestTime(_times[_currentLevel]));
        }
    }

    IEnumerator CrRestTime(float levelTime)
    {
        for (float i = levelTime; i > 0; i-= Time.deltaTime)
        {
            _timeBar.fillAmount = i / levelTime;
            yield return null;
        }
        //Pierde
        _timeBar.fillAmount = 0;
    }

    public void UseButton(int buttonIndex)
    {
        if (!_underCd)
        {
            print(buttonIndex);
            PlayLevel();
            StartCoroutine(CrCooldown());
        }
    }

    IEnumerator CrCooldown()
    {
        _underCd = true;
        yield return new WaitForSeconds(0.5f);
        _underCd = false;
    }
}
