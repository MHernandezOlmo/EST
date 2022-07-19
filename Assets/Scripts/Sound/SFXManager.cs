using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _fxASources;
    [SerializeField] private List<AudioClip> _clips;
    private int _currentSoundIndex;
    public enum AudioCode {SmoothSelect, InfoPanel, Back, Earned, Interact, Next, BlueEDeath, SoftShoot, EchoPops, Hit, Tornado,
    RobotShot, RobotHit, UIPanelSpawn, UIPanelDisappear, UIProblemSolved, UISpawn, UISelectMap, UISelectMenu, UIInstant, UINext,
    LGreenLight, LRedLight, LMetalDoor, LaserShoot, JetIgnition, MegaAnimation, MegaShot, MicrowaveShot, OvenRun, OvenShot, 
    ToasterJump, ToasterShot};

    private void Start()
    {
        AudioEvents.playSoundWithName.AddListener(PLayFXSound);
        AudioEvents.playSoundWithNameAndPitch.AddListener(PLayFXSoundPitch);
        AudioEvents.playSoundWithNameAndVolume.AddListener(PLayFXSoundVolume);
        AudioEvents.playSoundWithNameVolumeAndPitch.AddListener(PLayFXSoundVolumeAndPitch);
    }

    public void PLayFXSound(AudioCode audioCode)
    {
        _fxASources[_currentSoundIndex].clip = _clips[(int)audioCode];
        _fxASources[_currentSoundIndex].Play();
        _currentSoundIndex++;
        _currentSoundIndex %= _fxASources.Length;
    }
    public void PLayFXSoundPitch(AudioCode audioCode, float pitch)
    {
        _fxASources[_currentSoundIndex].pitch = pitch;
        _fxASources[_currentSoundIndex].clip = _clips[(int)audioCode];
        _fxASources[_currentSoundIndex].Play();
        StartCoroutine(CrWaitForAudioRestore(_currentSoundIndex));
        _currentSoundIndex++;
        _currentSoundIndex %= _fxASources.Length;
    }
    public void PLayFXSoundVolume(AudioCode audioCode, float volume)
    {
        _fxASources[_currentSoundIndex].volume = volume;
        _fxASources[_currentSoundIndex].clip = _clips[(int)audioCode];
        _fxASources[_currentSoundIndex].Play();
        StartCoroutine(CrWaitForAudioRestore(_currentSoundIndex));
        _currentSoundIndex++;
        _currentSoundIndex %= _fxASources.Length;
    }
    public void PLayFXSoundVolumeAndPitch(AudioCode audioCode, float volume, float pitch)
    {
        _fxASources[_currentSoundIndex].volume = volume;
        _fxASources[_currentSoundIndex].pitch = pitch;
        _fxASources[_currentSoundIndex].clip = _clips[(int)audioCode];
        _fxASources[_currentSoundIndex].Play();
        StartCoroutine(CrWaitForAudioRestore(_currentSoundIndex));
        _currentSoundIndex++;
        _currentSoundIndex %= _fxASources.Length;
    }

    IEnumerator CrWaitForAudioRestore(int aSourceIndex)
    {
        while (_fxASources[aSourceIndex].isPlaying)
        {
            yield return null;
        }
        _fxASources[aSourceIndex].pitch = 1f;
        _fxASources[aSourceIndex].volume = 1f;
    }
}
