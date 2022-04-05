using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManager;
    public enum MusicCode {None, Menu, Combat, FinalCinematic, Puzzle_0, Puzzle_1, Puzzle_2, Puzzle_3, Puzzle_4, EST, Gregor, Lomnicky, PicDuMidi, SST, TorreEinstein};
    [SerializeField] MusicCode musicCode;
    [SerializeField] private AudioSource _music;
    [SerializeField] private List<AudioClip> _musicClips;
    private bool _musicTransition, _usingMuteCr;
    private Coroutine _transitionCr, _muteCr;
    public static int currentClipIndex;
    
    private void Start()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(this);

        if (musicManager == null)
        {
            musicManager = this;
        }
        else if(musicManager != this)
        {
            Destroy(gameObject);
        }

        AudioEvents.playMusicTransitionWithMusicCode.AddListener(PlayMusicTransition);
        AudioEvents.muteMusic.AddListener(MuteMusic);
        AudioEvents.unmuteMusic.AddListener(UnmuteMusic);
        AudioEvents.playDefMusic.AddListener(PlayDefMusic);
       
        if(musicCode != MusicCode.None)
        {
            PlayMusicTransition(musicCode);
        }
        else if (currentClipIndex != (int)GetDefMusicCode() - 1)
        {
            PlayMusicTransition(GetDefMusicCode());
        }
    }


    public void PlayMusicTransition(MusicCode code)
    {
        currentClipIndex = (int)code -1;
        if (_transitionCr != null)
        {
            StopCoroutine(_transitionCr);
        }
        _transitionCr = StartCoroutine(MusicTransition((int)code - 1));
    }

    public IEnumerator MusicTransition(int musicIndex)
    {
        if (_usingMuteCr)
        {
            yield return null;
            _music.clip = _musicClips[musicIndex];
            _music.Play();
        }
        else
        {
            float dur = 1f;
            for (float i = 0; i < dur; i += Time.deltaTime)
            {
                _music.volume = 1 - i / dur;
                yield return null;
            }
            _music.volume = 0;
            _music.clip = _musicClips[musicIndex];
            _music.Play();
            for (float i = 0; i < dur; i += Time.deltaTime)
            {
                _music.volume = i / dur;
                yield return null;
            }
            _music.volume = 1;
        }
        _transitionCr = null;
    }

    public void MuteMusic()
    {
        if(_muteCr != null)
        {
            StopCoroutine(_muteCr);
        }
        _muteCr = StartCoroutine(CrSetVolume(0f));
    }

    public void UnmuteMusic()
    {
        if (_muteCr != null)
        {
            StopCoroutine(_muteCr);
        }
        _muteCr = StartCoroutine(CrSetVolume(1f));
    }

    IEnumerator CrSetVolume(float targetVol)
    {
        _usingMuteCr = true;
        float currentVol = _music.volume;
        float dur = 1f;

        for (float i = 0; i < dur; i+= Time.deltaTime)
        {
            yield return null;
            _music.volume = Mathf.Lerp(currentVol, targetVol, i/dur);
        }
        _music.volume = targetVol;
        _usingMuteCr = false;
        _muteCr = null;
    }

    public void PlayDefMusic()
    {
        PlayMusicTransition(GetDefMusicCode());
    }

    public MusicCode GetDefMusicCode()
    {
        MusicCode defCode = MusicCode.EST;

        char firstChar = GameProgressController.GetCurrentScene()[0];
        switch (firstChar)
        {
            case 'L':
                defCode = MusicCode.Lomnicky;
                break;
            case 'E':
                defCode = MusicCode.TorreEinstein;
                break;
            case 'G':
                defCode = MusicCode.Gregor;
                break;
            case 'P':
                defCode = MusicCode.PicDuMidi;
                break;
            case 'S':
                defCode = MusicCode.SST;
                break;
        }
        return defCode;
    }
}
