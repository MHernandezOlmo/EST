using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AudioSource[] _aSources;
    [SerializeField] private AudioClip[] _stepClips;
    [SerializeField] private float _walkCd;
    private int _currentIndex;
    private bool _underCd;

    private void Update()
    {
        if (!_playerMovement.IsJumping() && _playerMovement.IsGrounded())
        {
            float playerMovement = Mathf.Abs(_playerMovement.IsMoving());
            if (_playerMovement.IsRunning())
            {
                playerMovement *= 1.5f;
            }
            if (playerMovement > 0 && !_underCd)
            {
                StartCoroutine(Step(playerMovement));
            }
        }
    }

    public IEnumerator Step(float speed)
    {
        PlayStepSound();
        _underCd = true;
        yield return new WaitForSeconds(_walkCd / speed);
        _underCd = false;
    }
    public void PlayStepSound()
    {
        int randomN = Random.Range(0, _stepClips.Length);
        _aSources[_currentIndex].clip = _stepClips[randomN];
        _aSources[_currentIndex].Play();
        _currentIndex++;
        _currentIndex %= _aSources.Length;
    }
}
