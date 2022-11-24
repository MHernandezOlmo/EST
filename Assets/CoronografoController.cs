using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoronografoController : MonoBehaviour
{
    [SerializeField] Leveler[] _levelers;
    int _currentLeveler;
    [SerializeField] GameObject[] _lifeElements;
    int _lifes;
    int _currentStep;
    [SerializeField] Image _eclipse; 
    [SerializeField] Image[] _ticks;
    [SerializeField] GameObject _stopButton;
    [SerializeField] GameObject _takePhotoButton;
    PhotoFrame _photoFrameBehaviour;
    [SerializeField] private GameObject _resultImage;
    void Start()
    {
        _photoFrameBehaviour = FindObjectOfType<PhotoFrame>();
        _lifes = 3;
        _eclipse.rectTransform.localScale = Vector3.zero;
    }
    public void Stop()
    {
        _levelers[_currentLeveler].Check();
    }
    public void TakePhoto()
    {
        _photoFrameBehaviour.CheckPhoto();
    }
    public void LoseLife()
    {
        _lifes--;
        _lifeElements[_lifes].SetActive(false);
        if (_lifes <= 0)
        {
            FindObjectOfType<PuzzleStatesController>().GameOver();
        }
    }
    public void Next()
    {
        _currentStep++;
        _currentLeveler++;
        if (_currentLeveler >2)
        {
            if (_currentStep == 3)
            {
                _eclipse.rectTransform.localScale = (Vector3.one * 0.33f) * _currentStep;
                _photoFrameBehaviour.StopSun();
                _stopButton.SetActive(false);
                _takePhotoButton.SetActive(true);
            }
            else
            {
                _ticks[_currentStep - 4].gameObject.SetActive(true);
                _resultImage.SetActive(true);
                StartCoroutine(CrStopShowingResult());
                if (_currentStep == 6)
                {
                    FindObjectOfType<PuzzleStatesController>().Win();
                }
            }
        }
        else
        {
            _eclipse.rectTransform.localScale = (Vector3.one*0.33f)*_currentStep;
            _levelers[_currentLeveler].Activate();
        }
    }

    IEnumerator CrStopShowingResult()
    {
        yield return new WaitForSeconds(2f);
        _resultImage.SetActive(false);
    }
    public void StartGame()
    {
        _levelers[0].Activate();

    }
}
