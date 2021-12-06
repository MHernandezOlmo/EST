using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslationsSceneController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _globalInput;

    private TMP_InputField _currentInput;

    [SerializeField] private GameObject _inputPrefab;
    [SerializeField] private GameObject _inputListHolder;
    
    public void SelectInput(TMP_InputField _newInput)
    {
        _currentInput = _newInput;
        _globalInput.text = _currentInput.text;
    }
    void Start()
    {
        
    }

    public void Save()
    {
        
    }
    void Update()
    {
        
    }
}
