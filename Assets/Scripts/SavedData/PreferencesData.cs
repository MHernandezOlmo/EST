using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PreferencesData
{
    public bool _sfxEnabled;
    public bool _ostEnabled;
    public string _language;
    public PreferencesData()
    {
        _sfxEnabled = true;
        _ostEnabled = true;
        _language = "";
    }
    public PreferencesData(string language)
    {
        _sfxEnabled = true;
        _ostEnabled = true;
        _language = language;
    }
}
