using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspejoController : MonoBehaviour
{
    [SerializeField] MirrorRobot[] _robots;
    [SerializeField] MirrorDirt[] _dirts;
    private int _robotKills;
    public int RobotKills
    {
        get
        {
            return _robotKills;
        }
        set
        {
            _robotKills = value;

            if (_robotKills == 30)
            {
                FindObjectOfType<PuzzleStatesController>().Win();
            }
        }
    }
    public void StartGame()
    {

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
