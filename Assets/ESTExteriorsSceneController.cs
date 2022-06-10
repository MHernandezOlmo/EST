using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTExteriorsSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialogTrigger;
    [SerializeField] private DialogueTrigger _dialogTriggerPreCombat;
    private BadassEnemy _badassEnemy;
    private PlayerController _playerController;
    [SerializeField] private CinemachineVirtualCamera _bossCamera;
    bool _cameraShown;
    [SerializeField] private Animator _enemyGrowAnimator;

    public void RestoreCamera()
    {
        _bossCamera.Priority = 0;
        _enemyGrowAnimator.SetTrigger("Start");
        //FindObjectOfType<BadassAttack>().StartAttack();

    }
    IEnumerator Start()
    {
        _badassEnemy = FindObjectOfType<BadassEnemy>();
        _playerController = FindObjectOfType<PlayerController>();
        yield return new WaitForSeconds(1f);
        _dialogTrigger.triggerDialogueEvent(true);
    }

    IEnumerator CrCameraShown()
    {
        _cameraShown = true;
        _bossCamera.Priority = 50;
        _badassEnemy.StartAnimation();
        yield return new WaitForSeconds(2);
        FindObjectOfType<CameraShake>().ShakeCamera(0.4f, 6);
        yield return new WaitForSeconds(5);
        yield return new WaitForSeconds(3);
        _dialogTriggerPreCombat.triggerDialogueEvent(true);
        //FindObjectOfType<BadassAttack>().StartAttack();
        //yield return new WaitForSeconds(1);
        //_bossCamera.Priority = 0;
    }
    
    void Update()
    {
        if (!_cameraShown)
        {
            float distanceToBoss = Vector3.Distance(_badassEnemy.transform.position, _playerController.transform.position);
            if (distanceToBoss <= 60)
            {
                CurrentSceneManager._canMove = false;
                StartCoroutine(CrCameraShown());
            }
        }
    }
}
