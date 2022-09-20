using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Roulette : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    [SerializeField] private int itemAmount;
    private float degreesPerSection;
    [SerializeField] private AnimationCurve _animationCurve;
    private bool _turning;
    [SerializeField] private Sprite[] _sprites;
    private int _selectedSprite;
    private bool[] _sockets;
    [SerializeField] private Image[] _socketImages;
    [SerializeField] private Image[] _socketBorders;
    [SerializeField] private Color _selectableColor;
    private NewCardBehaviour[] _cards;
    private float _gameTime;
    [SerializeField] private Image _timeBarImage;
    private bool _gameStarted;
    [SerializeField] private float _totalGameTime;
    private bool _picking;
    
    [SerializeField] private Sprite[] _filamentsPhotosphereImages;
    [SerializeField] private Sprite[] _filamentsCoronaImages;
    [SerializeField] private Sprite[] _filamentsChromosphereImages;
    
    [SerializeField] private Sprite[] _proninencesPhotosphereImages;
    [SerializeField] private Sprite[] _prominencesCoronaImages;
    [SerializeField] private Sprite[] _prominenceChromosphereImages;
    
    [SerializeField] private Sprite[] _sunspotsPhotosphereImages;
    [SerializeField] private Sprite[] _sunspotsCoronaImages;
    [SerializeField] private Sprite[] _sunspotsChromosphereImages;
    private List<Sprite[]> _imageLibrary;
    
    public void RandomicePositions()
    {
        for (int i = 0; i < 100; i++)
        {
            int first = Random.Range(0, 9);
            int second = Random.Range(0, 9);
            int rotID = _cards[first]._rotationID;
            _cards[first]._rotationID = _cards[second]._rotationID;
            _cards[second]._rotationID = rotID;
            (_cards[first].transform.localPosition, _cards[second].transform.localPosition) = (_cards[second].transform.localPosition, _cards[first].transform.localPosition);
        }
    }

    public void StartGame()
    {
        _gameTime = _totalGameTime;
        _gameStarted = true;
    }
    void Start()
    {
        _imageLibrary = new List<Sprite[]>();

        _imageLibrary.Add(_filamentsCoronaImages);
        _imageLibrary.Add(_prominencesCoronaImages);
        _imageLibrary.Add(_sunspotsCoronaImages);

        _imageLibrary.Add(_filamentsChromosphereImages);
        _imageLibrary.Add(_prominenceChromosphereImages);
        _imageLibrary.Add(_sunspotsChromosphereImages);

        _imageLibrary.Add(_filamentsPhotosphereImages);
        _imageLibrary.Add(_proninencesPhotosphereImages);
        _imageLibrary.Add(_sunspotsPhotosphereImages);
        
        _cards = new NewCardBehaviour[itemAmount];
        _sockets = new bool[9];
        degreesPerSection= 360f / (float)itemAmount;
        for (int i = 0; i < itemAmount; i++)
        {
            _sprites[i] = _imageLibrary[i][Random.Range(0, _imageLibrary[i].Length)];
            transform.rotation = Quaternion.Euler(-degreesPerSection*i, 0,0);
            NewCardBehaviour selectable = Instantiate(_item, new Vector3(0, 0, -4), Quaternion.identity).GetComponent<NewCardBehaviour>();
            selectable.SetContent(_sprites[i]);
            selectable.SetID(i, this);
            _cards[i] = selectable;
            selectable.transform.SetParent(transform);
        }
        RandomicePositions();
        foreach(NewCardBehaviour n in FindObjectsOfType<NewCardBehaviour>())
        {
            if (n._rotationID == 8)
            {
                _selectedSprite = n.ID;
                _cards[_selectedSprite].ColorFrame(_selectableColor);
                for (int i = 0; i < _socketBorders.Length; i++)
                {
                    if (!_sockets[i])
                    {
                        _socketBorders[i].color = _selectableColor;
                    }
                }
            }
        }
    }

    public bool  GetCardValue(int cardIndex)
    {
        return _sockets[cardIndex];
    }
    
    public void RotateIntoID(int targetID, int targetRotationID)
    {
        if (!_turning && ! _picking)
        {
            if (!_sockets[targetID])
            {
                _selectedSprite = targetID;
            
                for (int i = 0; i < _socketBorders.Length; i++)
                {
                    if (!_sockets[i])
                    {
                        _socketBorders[i].color = _selectableColor;
                    }
                }
            }
            else
            {
                _selectedSprite = -1;
            }
            
            _turning = true;
            Quaternion targetRotation =Quaternion.Euler(-degreesPerSection*targetRotationID,0,0);
            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i].ColorFrame(Color.white);
            }
            _cards[targetID].ColorFrame(_selectableColor);
            StartCoroutine(CrRotateIntoID(transform.rotation,targetRotation));
        }
    }

    private void Update()
    {
        if (_gameStarted)
        {
            _gameTime -= Time.deltaTime;
            _timeBarImage.fillAmount = _gameTime/_totalGameTime;
            if (_gameTime < 0)
            {
                _gameStarted = false;
                FindObjectOfType<PuzzleStatesController>().GameOver();
            }
            else
            {
                bool won = true; 
                foreach (var s in _sockets)
                {
                    if (!s)
                    {
                        won = false;
                    }
                }
                if (won)
                {
                    _gameStarted = false;

                    FindObjectOfType<PuzzleStatesController>().Win();
                }
            }
        }

    }

    IEnumerator CrRotateIntoID(Quaternion startRotation, Quaternion targetRotation)
    {
        for (float i = 0; i < 0.5f; i += Time.deltaTime)
        {
            yield return null;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, _animationCurve.Evaluate(i/0.5f));
        }

        transform.rotation = targetRotation;
        _turning = false;
    }

    public void SelectSocket(int socket)
    {
        if (_selectedSprite >= 0)
        {
            if (!_picking)
            {
                _picking = true;
                if (socket == _selectedSprite)
                {
                    _socketImages[socket].sprite = _sprites[_selectedSprite];
                    _socketImages[socket].color = Color.white;
                    StartCoroutine(CrSuccessFeedback());
                    _sockets[socket] = true;
                }
                else
                {
                    StartCoroutine(CrFailFeedback());
                }
            }    
        }
    }

    IEnumerator CrSuccessFeedback()
    {
        for (int i = 0; i < _socketBorders.Length; i++)
        {
            if (!_sockets[i])
            {
                _socketBorders[i].color = Color.green;
            }
        }
        _cards[_selectedSprite].ColorFrame(Color.green);
        _cards[_selectedSprite].ColoContent(new Color(0.2f,0.2f,0.2f));

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < _socketBorders.Length; i++)
        {
            if (!_sockets[i])
            {
                _socketBorders[i].color = Color.white;
            }
        }
        _selectedSprite = -1;
        _picking = false;
    }
    
    IEnumerator CrFailFeedback()
    {
        for (int i = 0; i < _socketBorders.Length; i++)
        {
            if (!_sockets[i])
            {
                _socketBorders[i].color = Color.red;
            }
        }
        _cards[_selectedSprite].ColorFrame(Color.red);

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < _socketBorders.Length; i++)
        {
            if (!_sockets[i])
            {
                _socketBorders[i].color = _selectableColor;
            }
        }
        _cards[_selectedSprite].ColorFrame(_selectableColor);
        //_selectedSprite = -1;
        _picking = false;
    }
}
