using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SalaPrincipalSceneController : MonoBehaviour
{

    MovementController _player;
    [SerializeField]
    CinemachineVirtualCamera _c0;
    [SerializeField]
    CinemachineVirtualCamera _c1;
    [SerializeField]
    CinemachineVirtualCamera _c2;
    [SerializeField]
    CinemachineVirtualCamera _c3;
    [SerializeField] private  int _currentCamera;
    void Start()
    {
        
        _player = FindObjectOfType<MovementController>();
        //_player.autopilot = new Vector3(2.7f, 0.7f, -1.67f);
    }

    private void Update()
    {

    }
    public void ChangeCamera(int camera)
    {
        print(camera);
        if(CurrentSceneManager._elapsedSceneTime > 0.5f)
        {
            if (camera != _currentCamera)
            {

                StartCoroutine(CoChangeCamera(camera));
            }
        }
        else
        {
            _c0.Priority = 0;
            _c1.Priority = 0;
            _c2.Priority = 0;
            _c3.Priority = 0;

            switch (camera)
            {
                case 0:
                    _c0.Priority = 100;

                    break;

                case 1:
                    _c1.Priority = 100;

                    break;

                case 2:

                    _c2.Priority = 100;
                    break;
                case 3:

                    _c3.Priority = 100;
                    break;
            }
        }
        _currentCamera = camera;

    }

    IEnumerator CoChangeCamera(int targetCamera)
    {
        TransitionsController transitionController = FindObjectOfType<TransitionsController>();
        transitionController.FadeToBlack(0.5f);
        yield return new WaitForSeconds(0.5f);

        _c0.Priority = 0;
        _c1.Priority = 0;
        _c2.Priority = 0;
        _c3.Priority = 0;
        switch (targetCamera)
        {
            case 0:
            _c0.Priority = 100;

                break;

            case 1:
            _c1.Priority = 100;

                break;

            case 2:

            _c2.Priority = 100;
                break;
            case 3:

            _c3.Priority = 100;
                break;
        }

        transitionController.FadeFromBlack(0.5f);
        yield return new WaitForSeconds(0.5f);
    }
    

}
