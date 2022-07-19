using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioListenerClear : MonoBehaviour
{
    private AudioListener _aListener;
    void Awake()
    {
        _aListener = GetComponent<AudioListener>();
        AudioListener[] sceneListeners = FindObjectsOfType<AudioListener>();
        foreach(AudioListener a in sceneListeners)
        {
            if(a != _aListener)
            {
                a.enabled = false;
            }
        }
    }
}
