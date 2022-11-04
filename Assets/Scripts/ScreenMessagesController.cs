using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScreenMessagesController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _screenText;
    [SerializeField]
    GameObject _nextButton;
    int _counter;
    string _currentTextToShow;
    [SerializeField]
    Image _infoButton;
    [SerializeField]
    Image _background;
    [SerializeField]
    GameObject _screenMessagesHolder;
    Coroutine _crShowText;

    private void Awake()
    {
        GameEvents.ShowScreenText.AddListener(ShowText);
        _screenMessagesHolder.SetActive(false);
        _nextButton.SetActive(false);
    }
    
    void ShowText(string textToShow)
    {
        _currentTextToShow = textToShow;
        _counter = 0;
        if(_crShowText != null)
        {
            StopCoroutine(_crShowText);
        }
        _crShowText = StartCoroutine(CrShowText());
    }
    IEnumerator CrShowText()
    {
        _nextButton.gameObject.SetActive(false);
        _screenMessagesHolder.SetActive(true);
        RectTransform _rt = _screenMessagesHolder.GetComponent<RectTransform>();
        _screenText.text = _currentTextToShow;
        for (float i = 0; i< 0.1f; i += Time.deltaTime)
        {
            _rt.transform.localScale =0.75f* Vector3.one * i / 0.1f;
            yield return null;
        }
        _rt.transform.localScale = 0.75f * Vector3.one;

        yield return new WaitForSeconds(5f);
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            _rt.transform.localScale = 0.75f * Vector3.one *(1- (i / 0.1f));
            yield return null;
        }
        _rt.transform.localScale = Vector3.zero;
        _screenMessagesHolder.SetActive(false);
    }

    public void Next()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UINext);
        _counter++;
        StartCoroutine(CrShowText());
    }
}
