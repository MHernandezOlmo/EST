using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SalaAzoteaSceneController : MonoBehaviour
{
 
    MovementController _player;
    [SerializeField]
    CinemachineVirtualCamera _c0;
    [SerializeField]
    CinemachineVirtualCamera _c1;

    [SerializeField]
    CinemachineVirtualCamera _cinematicCamera;
    [SerializeField]
    AnimationCurve _animationCurve;
    int _currentCamera;
    [SerializeField]
    DialogueTrigger _openCupulaDialog;
    [SerializeField]
    GameObject _cupula;
    Quaternion _originalCupulaRotation;
    [SerializeField] GameObject[] _piezas;
    [SerializeField] GameObject _snowVFX;
    [SerializeField] GameObject _piezasCanvas;
    void Start()
    {
        _originalCupulaRotation = _cupula.transform.rotation;
        _player = FindObjectOfType<MovementController>();
        //_player.autopilot = new Vector3(2.7f, 0.7f, -1.67f);
        if (PlayerPrefs.GetInt("CinematicOpenCupula") == 1)
        {
            _piezasCanvas.SetActive(false);
            _snowVFX.SetActive(true);
            foreach(GameObject g in _piezas)
            {
                g.SetActive(false);
            }
            _player.gameObject.SetActive(false);
            foreach (Interactable interactable in FindObjectsOfType<Interactable>())
            {
                FindObjectOfType<InteractablesController>().RemoveInteractable(interactable);
                interactable.gameObject.SetActive(false);
            }
            
            GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
            PlayerPrefs.SetInt("CinematicOpenCupula", 0);
            _cinematicCamera.Priority = 1000;
            StartCoroutine(CrMoveCinematicCamera());
        }
        else
        {
            if (PlayerPrefs.GetInt("CinematicCloseCupula") == 1)
            {
                _piezasCanvas.SetActive(false);
                _snowVFX.SetActive(true);
                foreach (GameObject g in _piezas)
                {
                    g.SetActive(false);
                }
                _player.gameObject.SetActive(false);
                foreach (Interactable interactable in FindObjectsOfType<Interactable>())
                {
                    FindObjectOfType<InteractablesController>().RemoveInteractable(interactable);
                    interactable.gameObject.SetActive(false);
                }

                GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
                PlayerPrefs.SetInt("CinematicCloseCupula", 0);
                _cinematicCamera.Priority = 1000;
                StartCoroutine(CrMoveCinematicCameraAndClose());
            }
            else
            {
                _cupula.transform.rotation = Quaternion.Euler(0, 90, 90);

            }
        }
    }
    IEnumerator CrMoveCinematicCameraAndClose()
    {
        var dolly = _cinematicCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        for (float i = 0; i < 5f; i += Time.deltaTime)
        {
            if(i > 2)
            {
                float q = i - 2f;
                
                _cupula.transform.rotation = Quaternion.Slerp(_originalCupulaRotation, Quaternion.Euler(0, 90, 90), q / 3f);
            }
            dolly.m_PathPosition = _animationCurve.Evaluate(i / 5f) * 2;
            yield return null;
        }
        _cupula.transform.rotation = Quaternion.Euler(0, 90, 90);
        GameProgressController.SetCeilingClosed(true);

        //PlayerPrefs.SetInt("PreviousPoint", 2);
        GameProgressController.SetCurrentStartPoint(2);
        GameEvents.LoadScene.Invoke("Lomnicky_3_Sala contigua");
    }
    IEnumerator CrMoveCinematicCamera()
    {
        var dolly = _cinematicCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        bool showedDialog = false;
        for (float i = 0; i< 5f; i += Time.deltaTime)
        {
            if(i>3 && !showedDialog)
            {
                _openCupulaDialog.triggerDialogueEvent(true);
                showedDialog = true;
            }
            dolly.m_PathPosition = _animationCurve.Evaluate(i/5f)*2;
            yield return null;
        }
        while (CurrentSceneManager._state != GameStates.Exploration)
        {
            yield return null;
        }
        GameEvents.LoadScene.Invoke("Lomnicky_2_Sala llegada");
    }
    private void Update()
    {

    }
    public void ChangeCamera(int camera)
    {
        if (CurrentSceneManager._elapsedSceneTime > 0.5f)
        {
            if (camera != _currentCamera)
            {
                _currentCamera = camera;

                //StartCoroutine(CoChangeCamera(camera));
            }
        }
        else
        {
            _c0.Priority = 0;
            _c1.Priority = 0;

            switch (camera)
            {
                case 0:
                    _c0.Priority = 100;

                    break;

                case 1:
                    _c1.Priority = 100;

                    break;

  
            }
        }
    }

    //IEnumerator CoChangeCamera(int targetCamera)
    //{
    //    TransitionsController transitionController = FindObjectOfType<TransitionsController>();
    //    transitionController.FadeToBlack(0.5f);
    //    yield return new WaitForSeconds(0.5f);

    //    _c0.Priority = 0;
    //    _c1.Priority = 0;

    //    switch (targetCamera)
    //    {
    //        case 0:
    //            _c0.Priority = 100;

    //            break;

    //        case 1:
    //            _c1.Priority = 100;

    //            break;

    //    }

    //    transitionController.FadeFromBlack(0.5f);
    //    yield return new WaitForSeconds(0.5f);
    //}

}
