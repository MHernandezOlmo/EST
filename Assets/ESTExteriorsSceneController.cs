using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTExteriorsSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialogTrigger;
    [SerializeField] private DialogueTrigger _dialogTriggerPreCombat;
    [SerializeField] private GameObject _trappedCanvas, _enemyCollection, _combatButton, _dialogLauncher;
    [SerializeField] private RectTransform _trappedCanvasRT;

    private BadassEnemy _badassEnemy;
    private BadassAttack _badassAttack;
    private PlayerController _playerController;
    [SerializeField] private CinemachineVirtualCamera _bossCamera;
    bool _cameraShown;
    [SerializeField] private Animator _enemyGrowAnimator;

    void Start()
    {
        _badassEnemy = FindObjectOfType<BadassEnemy>();
        _badassAttack = FindObjectOfType<BadassAttack>();
        _playerController = FindObjectOfType<PlayerController>();
        if (GameProgressController.ESTEnemyCollection)
        {
            _enemyCollection.SetActive(false);
            _dialogLauncher.SetActive(false);
            //_bigEnemy.SetActive(true);
            _badassEnemy.ActivateBadassBoss();
            //_badassAttack.ContinuosAttack();
            _enemyGrowAnimator.SetTrigger("Start");
        }
    }

    public void RestoreCamera()
    {
        _bossCamera.Priority = 0;
        _enemyGrowAnimator.SetTrigger("Start");
        _combatButton.SetActive(true);
        //FindObjectOfType<BadassAttack>().StartAttack();
    }

    public void LaunchDialog()
    {
        _trappedCanvas.SetActive(true);
        StartCoroutine(CrShowCanvas()); 
    }

    IEnumerator CrShowCanvas()
    {
        _dialogTrigger.triggerDialogueEvent(true);
        yield return new WaitForSeconds(0.5f);
        for (float i = 0; i < 0.25f; i += Time.deltaTime)
        {
            _trappedCanvasRT.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i/0.25f);
            yield return null;
        }
        _trappedCanvasRT.localScale = Vector3.one;
    }

    public void HideCanvas()
    {
        StartCoroutine(CrHideCanvas());
    }

    IEnumerator CrHideCanvas()
    {
        for (float i = 0; i < 0.25f; i += Time.deltaTime)
        {
            _trappedCanvasRT.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i / 0.25f);
            yield return null;
        }
        _trappedCanvasRT.localScale = Vector3.zero;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator CrCameraShown()
    {
        _combatButton.SetActive(false);
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
        if (GameProgressController.ESTEnemyCollection)
        {
            return;
        }
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
