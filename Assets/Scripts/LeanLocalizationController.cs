using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using TMPro;

public class LeanLocalizationController : MonoBehaviour
{
    LeanLocalization _leanLocalization;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _leanLocalization = FindObjectOfType<LeanLocalization>();
        SetLanguage("English");
    }
    public string GetCurrentLanguage()
    {
        return LeanLocalization.CurrentLanguage;
    }
    public void SetLanguage(string newLanguage)
    {
        _leanLocalization.SetCurrentLanguage(newLanguage);
        SavedDataController.SetLanguage(newLanguage);
        if (LeanLocalization.CurrentLanguage == "English")
        {
            if (_textMeshPro != null)
            {
                _textMeshPro.text = $"Language: English";
            }
        }
        else
        {
            if (_textMeshPro != null)
            {
                _textMeshPro.text = $"Idioma: Español";
            }
        }
    }
}
