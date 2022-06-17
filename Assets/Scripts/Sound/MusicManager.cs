using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManager;
    public enum MusicCode {None, Menu, Combat, FinalCinematic, Puzzle_0, Puzzle_1, Puzzle_2, Puzzle_3, Puzzle_4, EST, Gregor, Lomnicky, PicDuMidi, SST, TorreEinstein};
    [SerializeField] MusicCode musicCode;
    [SerializeField] private AudioSource _music, _music2;
    [SerializeField] private List<string> _musicClipsNames, _insideClipsNames;
    [SerializeField] private AudioMixer _aMixer;
    [SerializeField] private AnimationCurve _aCurveIn, _aCurveOut;
    private bool _alternatedCh;
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

        if(FindObjectOfType<CurrentSceneManager>() != null)
        {
            if (FindObjectOfType<CurrentSceneManager>().IsExterior)
            {
                if (musicCode != MusicCode.None)
                {
                    PlayMusicTransition(musicCode);
                }
                else if (currentClipIndex != (int)GetDefMusicCode() - 1)
                {
                    PlayMusicTransition(GetDefMusicCode());
                }
            }
            else
            {
                PlayMusicTransition(Random.Range(0, _insideClipsNames.Count));
            }
        }
        else
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
        AudioClip targetClip = Resources.Load<AudioClip>("Music/MusicClips/" + _musicClipsNames[(int)code - 1]);
        _transitionCr = StartCoroutine(MusicTransition(targetClip));
    }
    public void PlayMusicTransition(int codeIndex)
    {
        currentClipIndex = -1;
        if (_transitionCr != null)
        {
            StopCoroutine(_transitionCr);
        }
        AudioClip targetClip = Resources.Load<AudioClip>("Music/RandomMusic/" + _insideClipsNames[codeIndex]);
        _transitionCr = StartCoroutine(MusicTransition(targetClip));
    }

    public IEnumerator MusicTransition(AudioClip clip)
    {
        AudioSource lastAsource = _music;
        AudioSource newAsource = _music2;
        if (_alternatedCh)
        {
            lastAsource = _music2;
            newAsource = _music;
        }
        float dur = 3f;

        newAsource.volume = 0;
        newAsource.clip = clip;
        newAsource.Play();

        for (float i = 0; i < dur; i += Time.deltaTime)
        {
            lastAsource.volume = 1 - _aCurveOut.Evaluate(i / dur);
            newAsource.volume = _aCurveIn.Evaluate(i / dur);
            yield return null;
        }
        lastAsource.volume = 0;
        newAsource.volume = 1;
        //for (float i = 0; i < dur; i += Time.deltaTime)
        //{
        //    lastAsource.volume = i / dur;
        //    yield return null;
        //}
        _transitionCr = null;
        _alternatedCh = !_alternatedCh;
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
        float currentVol;
        _aMixer.GetFloat("OSTParentVol", out currentVol);
        float dur = 1f;

        for (float i = 0; i < dur; i+= Time.deltaTime)
        {
            yield return null;
            _aMixer.SetFloat("OSTParentVol", Mathf.Lerp(currentVol, targetVol, i / dur));
        }
        _aMixer.SetFloat("OSTParentVol", targetVol);
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
