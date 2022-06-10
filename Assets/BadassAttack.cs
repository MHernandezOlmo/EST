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
        _aura.SetActive(true);
        _aura.GetComponent<ParticleSystem>().Play();
        transform.position = _playerController.transform.position;
        yield return new WaitForSeconds(2f);
        _explosion.Play();
        CheckPlayer();
        _aura.SetActive(false);
    }
    public IEnumerator CrExplodeAgain()
    {
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
            _playerController.ReceiveDamage(10000);
        }
    }

    public void StopAttack()
    {
        StopAllCoroutines();
        _aura.SetActive(false);
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

        }
        _previousState = CurrentSceneManager._state;
    }

}
