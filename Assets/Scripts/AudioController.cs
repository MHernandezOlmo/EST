using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{
    AudioMixer _master;
    AudioMixerGroup _sfxMixer;
    AudioMixerGroup _ostMixer;

    private void Awake()
    {
        GameEvents.ToggleOST.AddListener(ToggleOST);
        GameEvents.ToggleSFX.AddListener(ToggleSFX);
    }
    void Start()
    {
        _master = Resources.Load<AudioMixer>("Mixers/GameAudioMixer");
        ToggleOST(SavedDataController.IsOSTEnabled());
        ToggleSFX(SavedDataController.IsSFXEnabled());
    }
    public void ToggleOST(bool state)
    {
        if (state)
        {
            _master.SetFloat("OSTVolume", 0f);
        }
        else
        {
            _master.SetFloat("OSTVolume", -80f);
        }
        SavedDataController.SetOSTEnabled(state);
    }
    public void ToggleSFX(bool state)
    {
        if (state)
        {
            _master.SetFloat("SFXVolume", 0f);
        }
        else
        {
            _master.SetFloat("SFXVolume", -80f);
        }
        SavedDataController.SetSFXEnabled(state);
    }
}

