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
    [SerializeField] private Color[] _characterColors;
    bool _canClose;
    public void SetCurrentDialogue(TestDialogue newDialogue)
    {
        _currentDialogue = newDialogue;
    }
    void Awake()
    {
        GameEvents.eDialogue.AddListener(ShowDialogue);
    }
    private void OnEnable()
    {
        _canClose = false;
    }

    public void Next()
    {
        _canClose = false;
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
    private void Update()
    {
        if (_canClose)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Next();
            }
        }
    }
    public void Refresh()
    {
        string name = "Sprites/DNI Portraits/" + _currentDialogue.speakerFaces[_counter].ToString();
        Sprite faceSprite = Resources.Load<Sprite>(name);

        _name.text = _currentDialogue.speakerFaces[_counter].ToString();
        _mainText.color = _characterColors[(int)_currentDialogue.speakerFaces[_counter]];
        _name.color = _characterColors[(int)_currentDialogue.speakerFaces[_counter]];
        _faceImage.sprite = faceSprite;
        _faceImage.overrideSprite = faceSprite;
        _nextButton.SetActive(false);
        StartCoroutine(CrRefresh());
    }
    IEnumerator CrRefresh()
    {

        string translatedText = _currentDialogue.GetTranslatedText(_counter);
        _mainText.text = translatedText.Replace('%', '\n').Replace('$', '"');
        yield return new WaitForSeconds(0.5f);
        _nextButton.SetActive(true);
        yield return null;
        yield return null;
        _canClose = true;
    }
    void ShowDialogue(bool state)
    {
        _canClose = false;
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
