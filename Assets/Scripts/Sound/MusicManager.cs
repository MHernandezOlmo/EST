using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum MusicCode {Menu, Combat, FinalCinematic, Puzzle_0, Puzzle_1, Puzzle_2, Puzzle_3, Puzzle_4, EST, Gregor, Lomnicky, PicDuMidi, SST, TorreEinstein };
    [SerializeField] private AudioSource _music;
    [SerializeField] private List<AudioClip> _musicClips;
    private bool _musicTransition;
    private Coroutine _transitionCr;
    public static int currentClipIndex;

    private void Start()
    {
        AudioEvents.playMusicTransitionWithMusicCode.AddListener(PlayMusicTransition);
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
        float dur = 1f;
        _musicTransition = true;
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
        _musicTransition = false;
        _transitionCr = null;
    }
}
