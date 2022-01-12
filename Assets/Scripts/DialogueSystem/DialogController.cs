using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogController : MonoBehaviour
{
    TestDialogue _currentDialogue;
    [SerializeField]
    TextMeshProUGUI _name;
    [SerializeField]
    TextMeshProUGUI _mainText;
    [SerializeField]
    Image _faceImage;
    int _counter;
    [SerializeField]
    GameObject _nextButton;
    public void SetCurrentDialogue(TestDialogue newDialogue)
    {
        _currentDialogue = newDialogue;
    }
    void Awake()
    {
        GameEvents.eDialogue.AddListener(ShowDialogue);
    }

    public void Next()
    {
        Debug.Log("??");
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UINext);
        _counter++;
        if (_counter<_currentDialogue.speakerFaces.Length)
        {
            Refresh();
        }
        else
        {
            ExitDialogue();
            _currentDialogue.GetComponent<DialogueTrigger>().HandleDialogueFinished();
        }
        
    }
    public void ExitDialogue()
    {
        _nextButton.SetActive(false);
        StartCoroutine(CrExitDialogue());
    }

    public IEnumerator CrExitDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UIPanelDisappear);
        GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
    }

    public void Refresh()
    {
        string name = "Sprites/DNI Portraits/" + _currentDialogue.speakerFaces[_counter].ToString();
        Sprite faceSprite = Resources.Load<Sprite>(name);

        _name.text = _currentDialogue.speakerFaces[_counter].ToString();

        _mainText.text = _currentDialogue.GetTranslatedText(_counter);
        _faceImage.sprite = faceSprite;
        _faceImage.overrideSprite = faceSprite;
        _nextButton.SetActive(false);
        StartCoroutine(CrRefresh());
    }
    IEnumerator CrRefresh()
    {
        string translatedText = _currentDialogue.GetTranslatedText(_counter);
        _mainText.text = translatedText;
        yield return new WaitForSeconds(0.5f);
        _nextButton.SetActive(true);
    }
    void ShowDialogue(bool state)
    {
        _counter = 0;
        if (state)
        {
            GameEvents.ChangeGameState.Invoke(GameStates.Dialogue);
        }
        else
        {
            GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
        }

        _mainText.gameObject.SetActive(true);
        Refresh();
    }
}
