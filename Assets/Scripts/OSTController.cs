using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OSTController : MonoBehaviour
{
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();

    }

    public void DimMusic()
    {
        StartCoroutine(CrDimMusic());
    }
    public void UnDimMusic()
    {
        StartCoroutine(CrUnDimMusic());
    }
    public void ChangeSong(string newSong)
    {

        if (_source.clip.name != newSong)
        {
            StartCoroutine(CrChangeMusic(newSong));
        }
    }

    IEnumerator CrChangeMusic(string newSong)
    {
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _source.volume = 1f - (i );
            yield return null;
        }
        _source.clip = Resources.Load<AudioClip>(newSong);
        _source.Play();
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _source.volume = i ;
            yield return null;
        }

        _source.volume = 1f;
    }
    IEnumerator CrDimMusic()
    {
        for (float i = 0; i <1f; i += Time.deltaTime)
        {
            _source.volume = 1f - (i );
            yield return null;
        }

        _source.volume = 0;

    }
    IEnumerator CrUnDimMusic()
    {
        yield return null;

        if (_source.volume < 0.2f)
        {
            for (float i = 0; i < 1f; i += Time.deltaTime)
            {
                _source.volume = i ;
                yield return null;
            }
            _source.volume = 1f;
        }
    }
}
