using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EspejoController : MonoBehaviour
{
    [SerializeField] MirrorRobot[] _robots;
    [SerializeField] MirrorDirt[] _dirts;
    private int _robotKills;
    public int robotsCount;
    bool won;
    float _elapsedTime;
    float _totalTime;
    bool _playing;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _robotsCount;
    bool _polishing;
    int _polishCount;
    [SerializeField] private Image _mirrorImage;
    [SerializeField] private TextMeshProUGUI _polishText;
    [SerializeField] private Color _gray;
    public void AddRobot()
    {
        robotsCount++;
    }
    public int RobotKills
    {
        get
        {
            return _robotKills;
        }
        set
        {
            _robotKills = value;
            _robotsCount.SetText("Robots: "+_robotKills + "/30");
        }
    }
    public void StartGame()
    {
        _playing = true;
    }
    public void PolishTap()
    {
        if (_polishing)
        {
            _polishCount++;
            _mirrorImage.color = Color.Lerp(_gray, Color.white, _polishCount / 10f);
        }
    }
    void Update()
    {
        if (_polishing)
        {
            if (_polishCount >= 10)
            {
                if (!won)
                {
                    won = true;
                    FindObjectOfType<PuzzleStatesController>().Win();
                }
            }
        }
        if (_playing)
        {
            _elapsedTime += Time.deltaTime;
            _image.fillAmount = 1 - (_elapsedTime / _totalTime);
        }
        if (_robotKills == 30)
        {
            bool allClean = true;
            for(int i = 0; i< _dirts.Length; i++)
            {
                if (!_dirts[i]._clean)
                {
                    allClean = false;
                }
            }
            if (allClean)
            {
                if (!_polishing)
                {
                    _polishing = true;
                    _polishText.gameObject.SetActive(true);
                }
            }
        }
    }

    void Start()
    {
        _totalTime = 45f;
    }

    public void CreateDirt(Vector2 dirtAnchoredPosition)
    {
        foreach(MirrorDirt dirt in _dirts)
        {
            if (!dirt.ImageComponent.enabled)
            {
                dirt.CreateDirt(dirtAnchoredPosition);
                break;
            }
        }
    }
}
