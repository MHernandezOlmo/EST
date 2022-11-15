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
    List<List<Sprite>> _phenomenoms;
    List<int> _alreadySeenFilaments, _alreadySeenLoops, _alreadySeenSpicules, _alreadySeenSunSpots;
    float _totalTime;
    float _gameTime;
    bool _playing;
    [SerializeField] Image _timeBar;
    int _currentPhenomenom;
    int _selectedGroup;
    Camera _camera;
    int successAnswers;
    int neededAnswers = 15;
    PuzzleStatesController _puzzleMainController;
    public void SelectGroup(int currentGroup)
    {
        _selectedGroup= currentGroup;
    }

    public void CheckPhenomenom()
    {
        if (!_playing)
        {
            return;
        }
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
                
                successAnswers++;
                _progress.text = successAnswers + "/" + neededAnswers;
                if (successAnswers >= neededAnswers)
                {
                    _playing = false;
                    _puzzleMainController.Win();
                }
                else
                {
                    UpdatePhenomenom();
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
        int[] possiblePhenomenoms = new int[] {1,3,4,5};
        int previous = _currentPhenomenom;
        do
        {
            _currentPhenomenom = possiblePhenomenoms[Random.Range(0, possiblePhenomenoms.Length)];
        } while (_currentPhenomenom == previous);
        int random = Random.Range(0, _phenomenoms[_currentPhenomenom].Count);
        _targetPhenomenom.sprite = _phenomenoms[_currentPhenomenom][random];
        _phenomenoms[_currentPhenomenom].RemoveAt(random);
    }
    
    void Start()
    {
        _camera = Camera.main;
        _puzzleMainController = FindObjectOfType<PuzzleStatesController>();
        _gameTime = 60;
        _totalTime= 60;
        _phenomenoms = new List<List<Sprite>>();
        _phenomenoms.Add(new List<Sprite>(_brightPoints));
        _phenomenoms.Add(new List<Sprite>(_filaments));
        _phenomenoms.Add(new List<Sprite>(_flares));
        _phenomenoms.Add(new List<Sprite>(_loops));
        _phenomenoms.Add(new List<Sprite>(_spicules));
        _phenomenoms.Add(new List<Sprite>(_sunSpots));

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
