using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadassAttack : MonoBehaviour
{
    [SerializeField] GameObject _aura;
    [SerializeField] ParticleSystem _explosion;
    PlayerController _playerController;
    Coroutine _attack;
    public bool autoplay;
    GameStates _previousState;
    bool stopped;
    private IEnumerator Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        if (autoplay)
        {
            yield return new WaitForSeconds(1);
            ContinuosAttack();
        }
    }

    public void Attack()
    {
        StartCoroutine(CrExplode());
    }
    public void ContinuosAttack()
    {
        _attack= StartCoroutine(CrExplodeAgain());
    }
    public IEnumerator CrExplode()
    {
        if (!stopped)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.MegaShot);
            _aura.SetActive(true);
            _aura.GetComponent<ParticleSystem>().Play();
            transform.position = _playerController.transform.position;
            yield return new WaitForSeconds(2f);
            _explosion.Play();
            CheckPlayer();
            _aura.SetActive(false);
        }

    }
    public IEnumerator CrExplodeAgain()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.MegaShot);
        _aura.SetActive(true);
        _aura.GetComponent<ParticleSystem>().Play();
        transform.position = _playerController.transform.position;
        yield return new WaitForSeconds(2f);
        _explosion.Play();
        CheckPlayer();
        _aura.SetActive(false);
        yield return new WaitForSeconds(1f);
        _attack = StartCoroutine(CrExplodeAgain());
    }

    public void CheckPlayer()
    {
        if(Vector3.Distance(_playerController.transform.position, transform.position) < 1)
        {
            _playerController.ReceiveDamage(5000);
        }
    }

    public void StopAttack()
    {
        StopAllCoroutines();
        _aura.SetActive(false);
        stopped = true;
    }

    private void Update()
    {
        if(CurrentSceneManager._state==GameStates.Dialogue && _previousState!= GameStates.Dialogue)
        {
            StopAttack();
        }

        if (CurrentSceneManager._state == GameStates.Exploration && _previousState == GameStates.Dialogue)
        {
            if (SceneManager.GetActiveScene().name!= "EST_exterior EST")
            {
                ContinuosAttack();
            }
            else
            {
                stopped = false;
            }

        }
        _previousState = CurrentSceneManager._state;
    }

}
