using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpticaAdaptativaController : MonoBehaviour
{
    bool _playing;
    float _gameTime;
    float _totalTime;
    [SerializeField] Image _timeBar;
    [SerializeField] List<Button> _cards;
    List<CardBehaviour> _cardBehaviours;
    int _firstSelectedCard;
    int _secondSelectedCard;
    PuzzleStatesController _mainPuzzleController;
    bool _checking;
    [SerializeField] List<Sprite> _images;
    int _pairsFound;
    int _pairsNeeded;

    void Start()
    {
        _pairsNeeded = 5;
        _mainPuzzleController = FindObjectOfType<PuzzleStatesController>();
        _gameTime = 90;
        _totalTime = _gameTime;
        _cardBehaviours = new List<CardBehaviour>();
        _firstSelectedCard = -1;
        _secondSelectedCard= -1;
        
        for (int i = 0; i< _cards.Count; i++)
        {
            int captured = i;
            _cards[i].onClick.AddListener(()=>SelectCard(captured));
            _cardBehaviours.Add(_cards[i].GetComponent<CardBehaviour>());
            _cardBehaviours[i].SetImage(_images[i]);
        }
        for(int i = 0; i< 100; i++)
        {
            _cards[Random.Range(0,_cards.Count)].transform.SetSiblingIndex(Random.Range(0,_cards.Count));
        }
    }
    public void SelectCard(int cardIndex)
    {
        if (!_checking)
        {
            if (_firstSelectedCard < 0)
            {
                _firstSelectedCard = cardIndex;
                _cardBehaviours[cardIndex].Turn(true);
            }
            else
            {
                if (_secondSelectedCard < 0)
                {
                    _checking = true;
                    _secondSelectedCard = cardIndex;
                    _cardBehaviours[cardIndex].Turn(true);
                    StartCoroutine(CrCheck());
                }
            }
        }

    }
    IEnumerator CrCheck()
    {
        yield return new WaitForSeconds(1f);
        if (Mathf.Abs(_firstSelectedCard - _secondSelectedCard) == 5)
        {
            _mainPuzzleController.CorrectFeedback();
            _cardBehaviours[_firstSelectedCard].Hide();
            _cardBehaviours[_secondSelectedCard].Hide();
            _pairsFound++;
        }
        else
        {
            _mainPuzzleController.FailFeedback();
            _cardBehaviours[_firstSelectedCard].Turn(false);
            _cardBehaviours[_secondSelectedCard].Turn(false);
        }
        yield return new WaitForSeconds(0.5f);
        _firstSelectedCard = -1;
        _secondSelectedCard = -1;
        _checking = false;
        if (_pairsFound >= _pairsNeeded)
        {
            _playing = false;
            _mainPuzzleController.Win();
        }
    }
    public void StartPlaying()
    {
        _playing = true;
    }

    void Update()
    {
        if (_playing)
        {
            _gameTime -= Time.deltaTime;
            _timeBar.fillAmount = _gameTime / _totalTime;
            if (_gameTime <= 0)
            {
                _playing = false;
                _mainPuzzleController.GameOver();
            }
        }
    }
}
