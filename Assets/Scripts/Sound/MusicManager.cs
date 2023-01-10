using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManager;
    public enum MusicCode {None, Menu, Combat, FinalCinematic, Puzzle_0, Puzzle_1, Puzzle_2, Puzzle_3, Puzzle_4, EST, Gregor, Lomnicky, PicDuMidi, SST, TorreEinstein, Epic_1, Epic_2, Epic_3, Epic_4, Epic_5};
    [SerializeField] MusicCode musicCode;
    [SerializeField] private AudioSource _music, _music2;
    [SerializeField] private List<string> _musicClipsNames, _insideClipsNames;
    [SerializeField] private AudioMixer _aMixer;
    [SerializeField] private AnimationCurve _aCurveIn, _aCurveOut;
    [SerializeField] private AudioClip _combatMusic;
    private int _lastRandomIndex;
    private bool _alternatedCh;
    private Coroutine _transitionCr, _muteCr, _musicCheckCr;
    public static int currentClipIndex;
    
    private void Start()
    {
        _lastRandomIndex = -1;
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

        if(GameProgressController.GetCurrentScene() == "EST_Cupula" && GameProgressController.MirrorAdvice)
        {
            PlayMusicTransition(MusicCode.Epic_5);
            return;
        }
        if(FindObjectOfType<CurrentSceneManager>() != null)
        {
            if (FindObjectOfType<CurrentSceneManager>().IsExterior)
            {
                if (GameProgressController.GetCurrentScene() == "EST_exterior EST")
                {
                    PlayMusicTransition(MusicCode.Epic_1);
                }
                else if (GameProgressController.GetCurrentScene() == "EST_Cupula")
                {
                    PlayMusicTransition(MusicCode.Epic_4);
                }
                else if (musicCode != MusicCode.None)
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
                char firstChar = 'a';
                char secondChar = 'a';
                if (GameProgressController.GetCurrentScene().Length > 2)
                {
                    firstChar = GameProgressController.GetCurrentScene()[0];
                    secondChar = GameProgressController.GetCurrentScene()[1];
                }
                if(firstChar == 'E' && secondChar == 'S')
                {
                    PlayRandomEpic();
                }
                else
                {
                    PlayMusicTransition(GetRandomMusicIndex());
                }
            }
        }
        else
        {
            PlayMusicTransition(GetDefMusicCode());
        }     
    }

    public int GetLastRandomMusicIndex()
    {
        if (_lastRandomIndex == -1)
        {
            _lastRandomIndex = 0;
        }
        return _lastRandomIndex;
    }

    public int GetRandomESTIndex()
    {
        int randomIndex;
        int[] validIndexes = new int[] {8,10,11};
        if (_lastRandomIndex == -1)
        {
            randomIndex = Random.Range(0, validIndexes.Length);
        }
        else
        {
            do
            {
                randomIndex = Random.Range(0, validIndexes.Length);
            }
            while (validIndexes[randomIndex] == _lastRandomIndex);
        }
        _lastRandomIndex = randomIndex;
        return validIndexes[randomIndex];
    }

    public int GetRandomMusicIndex()
    {
        int randomIndex;
        if(_lastRandomIndex == -1)
        {
            randomIndex = Random.Range(0, _insideClipsNames.Count);
        }
        else
        {
            do
            {
                randomIndex = Random.Range(0, _insideClipsNames.Count);
            }
            while (randomIndex == _lastRandomIndex);
        }
        _lastRandomIndex = randomIndex;
        return randomIndex;
    }

    public void PlayMusicTransition(MusicCode code)
    {
        currentClipIndex = (int)code;
        if (_transitionCr != null)
        {
            StopCoroutine(_transitionCr);
        }
        AudioClip targetClip;
        if (code == MusicCode.Combat)
        {
            targetClip = _combatMusic;
        }
        else
        {
            targetClip = Resources.Load<AudioClip>("Music/MusicClips/" + _musicClipsNames[(int)code - 1]);
        }
        _transitionCr = StartCoroutine(MusicTransition(targetClip));
    }

    //RANDOM MUSIC
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
        if(clip.name != "0_Menu")
        {
            if (_musicCheckCr != null)
            {
                StopCoroutine(_musicCheckCr);
            }
            _musicCheckCr = StartCoroutine(CrCheckMusicFinish(newAsource));
        }

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

    IEnumerator CrCheckMusicFinish(AudioSource asource)
    {
        bool detected = false;
        while (asource.isPlaying)
        {
            if(asource.time > asource.clip.length - 4f && !detected)
            {
                char firstChar = 'a';
                char secondChar = 'a';
                if (GameProgressController.GetCurrentScene().Length > 2)
                {
                    firstChar = GameProgressController.GetCurrentScene()[0];
                    secondChar = GameProgressController.GetCurrentScene()[1];
                }
                if (GameProgressController.GetCurrentScene() == "EST_Cupula" && GameProgressController.MirrorAdvice)
                {
                    PlayMusicTransition(MusicCode.Epic_5);
                }
                else if (firstChar == 'E' && secondChar == 'S')
                {
                    PlayRandomEpic();
                }
                else if (firstChar == 'S')
                {
                    if(!GameProgressController.SSTHasAO && GameProgressController.SSTShieldSkill)
                    {
                        PlayRandomEpic();
                    }
                }
                else
                {
                    PlayMusicTransition(Random.Range(0, _insideClipsNames.Count));
                }
                detected = true;
            }
            yield return null;
        }
    }

    public void PlayRandomEpic()
    {
        int rIndex = Random.Range(0, 3);
        switch (rIndex)
        {
            case 0:
                PlayMusicTransition(MusicCode.Epic_2);
                break;
            case 1:
                PlayMusicTransition(MusicCode.Epic_3);
                break;
            case 2:
                PlayMusicTransition(MusicCode.Epic_5);
                break;
        }
    }

    public void MuteMusic()
    {
        if(_muteCr != null)
        {
            StopCoroutine(_muteCr);
        }
        _muteCr = StartCoroutine(CrSetVolume(-80f));
    }

    public void UnmuteMusic()
    {
        if (_muteCr != null)
        {
            StopCoroutine(_muteCr);
        }
        _muteCr = StartCoroutine(CrSetVolume(0f));
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
        //if (SceneManager.GetActiveScene().name == "MainMenu")
        //{
        //    return MusicCode.Menu;
        //}
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
