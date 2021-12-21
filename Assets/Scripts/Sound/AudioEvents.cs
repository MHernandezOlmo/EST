using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class AudioEvents
{
    public static AudioCodeEvent playSoundWithName = new AudioCodeEvent();
    public static AudioCodeFloatEvent playSoundWithNameAndPitch = new AudioCodeFloatEvent();
    public static AudioCodeFloatEvent playSoundWithNameAndVolume = new AudioCodeFloatEvent();
    public static AudioCodeTwoFloatsEvent playSoundWithNameVolumeAndPitch = new AudioCodeTwoFloatsEvent();
    public static AudioEvent playMusicTransitionWithIndex = new AudioEvent();
    public static AudioEvent playMusicLoopWithIndex = new AudioEvent();

    public class AudioCodeEvent : UnityEvent<SFXManager.AudioCode> { };
    public class AudioCodeFloatEvent : UnityEvent<SFXManager.AudioCode, float> { };
    public class AudioCodeTwoFloatsEvent : UnityEvent<SFXManager.AudioCode, float, float> { };
    public class AudioEvent : UnityEvent<int> { };
}
