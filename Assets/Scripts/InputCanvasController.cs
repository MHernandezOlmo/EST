using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject _inputCanvas;
    [SerializeField]
    GameObject _interactButton;
    [SerializeField]
    GameObject _combatButton;
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _contentText;
    List<string> _titles;
    List<string> _content;
    [SerializeField] GameObject _SolarPedia;
    Coroutine _hidingInteractButton;
    bool _isShowing;
    InteractableUIPoolController _interactableUIPoolController;
    private void Awake()
    {
        _combatButton.SetActive(false);
        _interactButton.SetActive(false);
        GameEvents.CombatEvent.AddListener(ShowCombatButton);
        _titles = new List<string>();
        _titles.Add("Entry 0");
        _titles.Add("Entry 1");
        _titles.Add("Entry 2");
        _titles.Add("Entry 3");
        _titles.Add("Entry 4");
        _titles.Add("Entry 5");
        _titles.Add("Entry 6");
        _content = new List<string>();
        _content.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean tristique a dui ut bibendum. Nam ut euismod justo, rhoncus placerat velit. Curabitur vestibulum sapien pretium sapien porttitor mollis. Quisque mattis ornare nulla sed hendrerit. Proin tempus libero sapien. Nunc elit lectus, vestibulum id tempor vitae, luctus et nulla. ");
        _interactableUIPoolController = FindObjectOfType<InteractableUIPoolController>();
    }
    public void ShowContent(int index)
    {
        StartCoroutine(CoChangeText(index));
    }
    IEnumerator CoChangeText(int index)
    {
        for(float i =0; i<0.5f; i += Time.deltaTime)
        {
            yield return null;
            _contentText.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), i / 0.5f);
            _titleText.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), i / 0.5f);
        }
        _titleText.color = new Color(1, 1, 1, 0);
        _contentText.color = new Color(1, 1, 1, 0);
        _titleText.text = _titles[index];
        for (float i = 0; i < 0.5f; i += Time.deltaTime)
        {
            yield return null;
            _contentText.color = Color.Lerp(new Color(1, 1, 1, 0),new Color(1, 1, 1, 1),  i / 0.5f);
            _titleText.color = Color.Lerp(new Color(1, 1, 1, 0),new Color(1, 1, 1, 1),  i / 0.5f);
        }
        _titleText.color = new Color(1, 1, 1, 1);
        _contentText.color = new Color(1, 1, 1, 1);
    }
    
    public void ShowCombatButton(bool showState)
    {
        StartCoroutine(CrShowCombatButton(showState));
    }
    public void Pause()
    {
        //rrentSceneManager.SetGameState(GameStates.Pause);
        Time.timeScale = 0f;
        FindObjectOfType<PauseCanvasController>().Show(false);
    }
    public void ShowSolarPedia()
    {
        Time.timeScale = 0f;
        FindObjectOfType<PauseCanvasController>().Show(true);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        _SolarPedia.SetActive(false);
    }
   
    IEnumerator CrShowInteractable(bool state)
    {
        RectTransform rt = _interactButton.GetComponent<RectTransform>();
        if (state)
        {
            rt.localScale = Vector3.zero;
            _interactButton.SetActive(true);
            for (float i = 0; i < 0.1f; i += Time.deltaTime)
            {
                rt.localScale = Vector3.one * (i / 0.1f);
                yield return null;
            }
            rt.localScale = Vector3.one;
        }
        else
        {
            for (float i = 0; i < 0.1f; i += Time.deltaTime)
            {
                rt.localScale =Vector3.one -  Vector3.one * (i / 0.1f);
                yield return null;
            }
            rt.localScale = Vector3.zero;
            _interactButton.SetActive(false);
        }
        
    }

    IEnumerator CrShowCombatButton(bool state)
    {
        RectTransform rt = _combatButton.GetComponent<RectTransform>();
        if (state)
        {
            rt.localScale = Vector3.zero;
            _combatButton.SetActive(true);
            for (float i = 0; i < 0.25f; i += Time.deltaTime)
            {
                rt.localScale = Vector3.one * (i / 0.25f);
                yield return null;
            }
            rt.localScale = Vector3.one;
        }
        else
        {
            for (float i = 0; i < 0.25f; i += Time.deltaTime)
            {
                rt.localScale = Vector3.one - Vector3.one * (i / 0.25f);
                yield return null;
            }
            rt.localScale = Vector3.zero;
            _combatButton.SetActive(false);
        }

    }
    private void Update()
    {
        if (_interactableUIPoolController.GetSelectedInteractable() >= 0)
        {
            if (!_isShowing)
            {
                _isShowing = true;
                if (_hidingInteractButton != null)
                {
                    StopCoroutine(_hidingInteractButton);
                }
                _hidingInteractButton = StartCoroutine(CrShowInteractable(true));
            }
        }
        else
        {
            if (_isShowing)
            {
                _isShowing = false;
                if (_hidingInteractButton != null)
                {
                    StopCoroutine(_hidingInteractButton);
                }
                _hidingInteractButton= StartCoroutine(CrShowInteractable(false));
            }
        }
    }
    private void Start()
    {
    }
    public void Show()
    {
        _inputCanvas.SetActive(true);
    }
    
    public void Hide()
    {
        _inputCanvas.SetActive(false);
    }
}
