using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCContiguaInteractable : Interactable
{
    [SerializeField]
    Image _pc;
    [SerializeField]
    TMPro.TextMeshProUGUI _answerText;
    public override void Interact()
    {


        GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
        StartCoroutine(CrShowTablon());
    }
    public void Hide()
    {
        StartCoroutine(CrHideTablon());
    }
    public void Comprobar()
    {
        if(_answerText.text == "#6428771")
        {
            StartCoroutine(CrHideTablon());
            PlayerPrefs.SetInt("CinematicCloseCupula", 1);
            GameEvents.LoadScene.Invoke("Lomnicky_10_Azotea");
        }
        else
        {
            Clear();
        }
    }
    public void AddNumber(int number)
    {
        if (_answerText.text.Length <=7)
        {
            _answerText.text += number;
        }
        
    }
    public void Clear()
    {
        _answerText.text = "#";
    }
    IEnumerator CrHideTablon()
    {
        Color transparentWhite = new Color(1, 1, 1, 0);
        for (float i = 0; i < 0.25f; i += Time.deltaTime)
        {
            _pc.color = Color.Lerp(Color.white, transparentWhite, i / 0.25f);
            _pc.rectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i / 0.25f);
            yield return null;
        }
        _pc.rectTransform.localScale = Vector3.zero;
        GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
    }
    IEnumerator CrShowTablon()
    {
        Color transparentWhite = new Color(1, 1, 1, 0);
        for (float i = 0; i < 0.25f; i += Time.deltaTime)
        {
            _pc.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _pc.rectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.25f);
            _pc.color = Color.white;
            yield return null;
        }
        _pc.rectTransform.localScale = Vector3.one;
    }
    private void Awake()
    {
        if (GameProgressController.IsCeilingClosed())
        {
            gameObject.SetActive(false);
        }
    }
}
