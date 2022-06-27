using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AsociacionElementosController : MonoBehaviour
{
    [SerializeField] Sprite[] _brightPoints, _filaments, _flares, _loops,  _spicules, _sunSpots;
    [SerializeField] SpriteRenderer _targetPhenomenom;
    [SerializeField] TextMeshProUGUI _progress;
    List<Sprite[]> _phenomenoms;
    float _totalTime;
    float _gameTime;
    bool _playing;
    [SerializeField] Image _timeBar;
    int _currentPhenomenom;
    int _selectedGroup;
    Camera _camera;
    int successAnswers;
    int neededAnswers = 10;
    PuzzleStatesController _puzzleMainController;
    public void SelectGroup(int currentGroup)
    {
        _selectedGroup= currentGroup;
    }

    public void CheckPhenomenom()
    {
        Vector3 worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        Vector3 origin = worldPoint;
        origin.z = -3f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,20, 1 << 6))
        {
            _selectedGroup = int.Parse(hit.collider.gameObject.name);
            if (_currentPhenomenom == _selectedGroup)
            {
                FindObjectOfType<PuzzleStatesController>().CorrectFeedback();
                UpdatePhenomenom();
                _gameTime += 5f;
                successAnswers++;
                _progress.text = successAnswers + "/" + neededAnswers;
                if (successAnswers >= neededAnswers)
                {
                    _playing = false;
                    _puzzleMainController.Win();
                }
            }
            else
            {
                _gameTime -= 5f;
                _puzzleMainController.FailFeedback();
            }
        }
    }

    public void UpdatePhenomenom()
    {
        int previous = _currentPhenomenom;
        do
        {
            _currentPhenomenom = Random.Range(0, _phenomenoms.Count);
        } while (_currentPhenomenom == previous);
        _targetPhenomenom.sprite = _phenomenoms[_currentPhenomenom][Random.Range(0, _phenomenoms[_currentPhenomenom].Length)];
    }
    
    void Start()
    {
        _camera = Camera.main;
        _puzzleMainController = FindObjectOfType<PuzzleStatesController>();
        _gameTime = 60;
        _totalTime= 60;
        _phenomenoms = new List<Sprite[]>();
        _phenomenoms.Add(_brightPoints);
        _phenomenoms.Add(_filaments);
        _phenomenoms.Add(_flares);
        _phenomenoms.Add(_loops);
        _phenomenoms.Add(_spicules);
        _phenomenoms.Add(_sunSpots);
        UpdatePhenomenom();
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
                FindObjectOfType<PuzzleStatesController>().GameOver();
            }
        }
    }
}
