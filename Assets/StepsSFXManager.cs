using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSFXManager : MonoBehaviour
{
    [SerializeField] AudioSource[] _aSources;
    private int _currentIndex;
    private bool _go;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void Step()
    {
        _go = !_go;
        if (_go && _animator.GetFloat("MovementBlend") > 0.1f)
        {
            _aSources[_currentIndex].pitch = Random.Range(0.4f, 0.6f);
            _aSources[_currentIndex].Play();
            _currentIndex++;
            _currentIndex %= _aSources.Length;
        }
    }
}
