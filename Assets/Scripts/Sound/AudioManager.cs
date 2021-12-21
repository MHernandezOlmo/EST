using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    private bool _fxActive = true, _musicActive = true;
    [SerializeField] private AudioMixer _audioMixer;
    private float _defSFXDb = 0f, _defMusicDb = -10f;

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (audioManager != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        CheckPlayerPrefs();
    }


    ///SOUND SETTINGS
    ///
    public void ToggleFX(bool state)
    {
        _fxActive = state;
        RefreshFXState();
    }
    public void RefreshFXState() //0 = unmuted; 1 = muted
    {
        if (_fxActive)
        {
            PlayerPrefs.SetInt("FXState", 0);
            _audioMixer.SetFloat("FXVol", PlayerPrefs.GetFloat("FXVol") / 2f);
        }
        else
        {
            PlayerPrefs.SetInt("FXState", 1);
            _audioMixer.SetFloat("FXVol", -80);
        }
    }
    public void ToggleMusic(bool state)
    {
        _musicActive = state;
        RefreshMusicState();
    }
    public void RefreshMusicState() //0 = unmuted; 1 = muted
    {
        if (_musicActive)
        {
            //aqui pondremos el value del slider
            PlayerPrefs.SetInt("MusicState", 0);
            _audioMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol") / 2f);
        }
        else
        {
            PlayerPrefs.SetInt("MusicState", 1);
            _audioMixer.SetFloat("MusicVol", -80);
        }
    }

    public void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("FXState"))
        {
            if (PlayerPrefs.GetInt("FXState") == 1) //0 = unmuted; 1 = muted
            {
                _fxActive = false;
            }
            else
            {
                _fxActive = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("FXState", 0);
            PlayerPrefs.SetFloat("FXVol", _defSFXDb);
        }

        if (PlayerPrefs.HasKey("MusicState"))
        {
            if (PlayerPrefs.GetInt("MusicState") == 1) //0 = unmuted; 1 = muted
            {
                _musicActive = false;
            }
            else
            {
                _musicActive = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("MusicState", 0);
            PlayerPrefs.SetFloat("MusicVol", _defMusicDb);
        }
        RefreshFXState();
        RefreshMusicState();
    }

    public void SetFXVol(float value)
    {
        PlayerPrefs.SetFloat("FXVol", value);
    }
    public void SetMusicVol(float value)
    {
        PlayerPrefs.SetFloat("MusicVol", value);
    }

    public bool GetFXState()
    {
        return _fxActive;
    }
    public bool GetMusicState()
    {
        return _musicActive;
    }
}
