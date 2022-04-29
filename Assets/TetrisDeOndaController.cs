using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TetrisDeOndaController : MonoBehaviour
{
    [SerializeField] GameObject[] _waves;
    [SerializeField] GameObject _wavesHolder;
    [SerializeField] RectTransform[] _spawnPoints;
    [SerializeField] RectTransform[] _wavebuttons;
    List<List<RectTransform>> _instantiatedWaves;
    float _spawnTime;
    float _elapsedTime;
    Camera _camera;
    int _score;
    int _lifes;
    bool _playing;
    [SerializeField] GameObject[] _heart;
    void Start()
    {
        _camera = Camera.main;
        _spawnTime = 3f;
        _instantiatedWaves = new List<List<RectTransform>>();
        _instantiatedWaves.Add(new List<RectTransform>());
        _instantiatedWaves.Add(new List<RectTransform>());
        _instantiatedWaves.Add(new List<RectTransform>());
        _instantiatedWaves.Add(new List<RectTransform>());
        _lifes = 3;
    }
    public void Spawn(int wave)
    {
        RectTransform newWave = Instantiate(_waves[wave], _wavesHolder.transform).GetComponent<RectTransform>();
        newWave.position = _spawnPoints[wave].position;
        _instantiatedWaves[wave].Add(newWave);
    }
    void Update()
    {
        if (_playing)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _spawnTime)
            {
                _spawnTime = Random.Range(0.5f, 1f);
                _elapsedTime = 0f;
                Spawn(Random.Range(0, 4));
            }


            for (int i = 0; i < _instantiatedWaves.Count; i++)
            {
                for (int j = 0; j < _instantiatedWaves[i].Count; j++)
                {
                    if (_instantiatedWaves[i][j].position.x < 0)
                    {
                        LoseLife();
                        GameObject g = _instantiatedWaves[i][j].gameObject;
                        _instantiatedWaves[i].RemoveAt(j);
                        Destroy(g);
                    }
                }
            }
        }
    }
    public void StartPlaying()
    {
        _playing = true;
    }

    public void LoseLife()
    {

        _lifes--;
        _heart[_lifes].SetActive(false);
        if (_lifes<=0)
        {
            _playing = false;
            FindObjectOfType<PuzzleStatesController>().GameOver();
        }
    }

    public void Check(int waveRow)
    {
        if (_playing)
        {
            for (int i = 0; i < _instantiatedWaves[waveRow].Count; i++)
            {
                if (Vector3.Distance(_camera.ScreenToViewportPoint(_instantiatedWaves[waveRow][i].position), _camera.ScreenToViewportPoint(_wavebuttons[waveRow].position)) < 0.1f)
                {
                    _instantiatedWaves[waveRow][i].GetComponent<Wave>().TransformToOndaPlana();
                    _instantiatedWaves[waveRow].RemoveAt(i);
                    _score++;
                    if (_score >= 30)
                    {
                        _playing = false;
                        FindObjectOfType<PuzzleStatesController>().Win();
                    }
                    break;
                }
            }
        }
    }
}
