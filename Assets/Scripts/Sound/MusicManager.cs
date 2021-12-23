using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum MusicCode {Menu, Combat, FinalCinematic, Puzzle_0, Puzzle_1, Puzzle_2, Puzzle_3, Puzzle_4, EST, Gregor, Lomnicky, PicDuMidi, SST, TorreEinstein };
    [SerializeField] private AudioSource _music;
    [SerializeField] private List<AudioClip> _musicClips;
    private bool _musicTransition, _usingMuteCr;
    private Coroutine _transitionCr, _muteCr;
    public static int currentClipIndex;

    private void Start()
    {
        AudioEvents.playMusicTransitionWithMusicCode.AddListener(PlayMusicTransition);
        AudioEvents.muteMusic.AddListener(MuteMusic);
        AudioEvents.unmuteMusic.AddListener(UnmuteMusic);
    }

    public void PlayMusicTransition(MusicCode code)
    {
        currentClipIndex = (int)code;
        if (_transitionCr != null)
        {
            StopCoroutine(_transitionCr);
        }
        _transitionCr = StartCoroutine(MusicTransition((int)code));
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
}
