using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSFXManager : MonoBehaviour
{
    [SerializeField] float _volume, _minPitch, _maxPitch;
    [SerializeField] AudioClip _stepSound;
    [SerializeField] AudioSource[] _aSources;
    [SerializeField] bool _isPlayer;
    private int _currentIndex;
    private bool _go;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        foreach(AudioSource aS in _aSources)
        {
            aS.clip = _stepSound;
            aS.volume = _volume;
        }
    }


    public void Step()
    {
        if (_isPlayer)
        {
            _go = !_go;
            if (_go && _animator.GetFloat("MovementBlend") > 0.1f)
            {
                _aSources[_currentIndex].pitch = Random.Range(_minPitch, _maxPitch);
                _aSources[_currentIndex].Play();
                _currentIndex++;
                _currentIndex %= _aSources.Length;
            }
        }
        else
        {
            _aSources[_currentIndex].pitch = Random.Range(_minPitch, _maxPitch);
            _aSources[_currentIndex].Play();
            _currentIndex++;
            _currentIndex %= _aSources.Length;
        }
    }
}
