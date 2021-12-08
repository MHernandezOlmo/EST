using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using UnityEngine.Serialization;

public class TestDialogue : MonoBehaviour
{
    public enum Speakers { ECLIPSE, UV, MSPROMINENCE, FLARE, SPECTRO, SPOT};
    public Speakers[] speakerFaces;

    [SerializeField]
    [LeanTranslationName]
    private string[] translationName;

    public string GetTranslatedText(int index)
    {
        return LeanLocalization.GetTranslationText(translationName[index]).Replace("&",",");
    }
}
