using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music, _intro;
    [SerializeField] private List<AudioClip> _musicClips;
    private bool _musicTransition;
    private float _pitchAmount = 0.7f, _globalPitch;
    private Coroutine _transitionCr;

    private void Start()
    {
        _globalPitch = 1f;
        AudioEvents.playMusicLoopWithIndex.AddListener(PlayMusicLoop);
        AudioEvents.playMusicTransitionWithIndex.AddListener(PlayMusicTransition);
    }

    public void PlayMusicTransition(int musicIndex)
    {
        if (_transitionCr != null)
        {
            StopCoroutine(_transitionCr);
        }
        _transitionCr = StartCoroutine(MusicTransition(musicIndex));
    }
    public void PlayMusicLoop(int musicIndex)
    {
        StartCoroutine(CoWaitForLoop(musicIndex));
    }

    IEnumerator CoWaitForLoop(int musicIndex)
    {
        while (_musicTransition)
        {
            yield return null;
        }
        yield return null;

        _music.loop = false;
        while (_music.isPlaying)
        {
            yield return null;
        }
        _music.clip = _musicClips[musicIndex];
        _music.loop = true;
        _music.Play();
    }

    public IEnumerator MusicTransition(int musicIndex)
    {
        float dur = 1f;
        _musicTransition = true;
        for (float i = 0; i < dur; i += Time.deltaTime)
        {
            _music.volume = 1 - i / dur;
            _music.pitch = Mathf.Clamp(1 + _pitchAmount - i / dur, _pitchAmount, 1f) * _globalPitch;
            yield return null;
        }
        _music.volume = 0;
        _music.pitch = _pitchAmount * _globalPitch;
        _music.clip = _musicClips[musicIndex];
        _music.Play();
        for (float i = 0; i < dur; i += Time.deltaTime)
        {
            _music.volume = i / dur;
            _music.pitch = Mathf.Clamp(_pitchAmount + i / dur, _pitchAmount, 1f) * _globalPitch;
            yield return null;
        }
        _music.volume = 1;
        _music.pitch = 1 * _globalPitch;
        _musicTransition = false;
        _transitionCr = null;
    }

    public void SetGlobalPitch(float target)
    {
        _globalPitch = target;
        _music.pitch = _globalPitch;
    }
}
