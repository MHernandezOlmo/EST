using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspejoController : MonoBehaviour
{
    [SerializeField] MirrorRobot[] _robots;
    [SerializeField] MirrorDirt[] _dirts;
    private int _robotKills;
    public int robotsCount;
    bool won;
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

        }
    }
    public void StartGame()
    {

    }

    void Update()
    {
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
                if (!won)
                {
                    won = true;
                    FindObjectOfType<PuzzleStatesController>().Win();
                }
            }
        }
    }

    void Start()
    {
        
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
