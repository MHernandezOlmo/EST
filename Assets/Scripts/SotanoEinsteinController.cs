using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SotanoEinsteinController : MonoBehaviour
{
    [SerializeField] GameObject _sotanoAxis0;
    [SerializeField] GameObject _sotanoAxis1;
    [SerializeField] GameObject _firstRay;
    [SerializeField] GameObject _dialog;
    bool _correctPositionAxis0;
    bool _correctPositionAxis1;

    [SerializeField] GameObject _ray;
    [SerializeField] GameObject _basementDoor;
    bool _openBasementDoor;
    private bool _moving0;
    private bool _moving1;
    [SerializeField] private GameObject mirrorPoint;
    public void Advice()
    {
        _dialog.GetComponent<DialogueTrigger>().triggerDialogueEvent(true);
    }
    void Start()
    {
        if (GameProgressController.EinsteinDomeAxis2 && GameObject.Find("MissionText").GetComponent<TextMeshProUGUI>().text == "Get back to basement")
        {
            GameEvents.ClearMissionText.Invoke();
        }
        if (GameProgressController.EinsteinPlacedMirror && !GameProgressController.EinsteinBasementAxis0)
        {
            GameEvents.ClearMissionText.Invoke();
        }
        if (GameProgressController.GetIsFullRayWorking())
        {
            _firstRay.GetComponent<LineRenderer>().SetPosition(1,mirrorPoint.transform.position);
            _firstRay.SetActive(true);
            _dialog.SetActive(false);
        }
        else
        {
            _firstRay.SetActive(false);
        }
        _correctPositionAxis0 = GameProgressController.EinsteinBasementAxis0;
        _correctPositionAxis1 = GameProgressController.EinsteinBasementAxis1;
        _openBasementDoor = GameProgressController.GetOpenEinsteinBasementDoor();
        if (_correctPositionAxis0)
        {
            _sotanoAxis0.transform.localRotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            _sotanoAxis0.transform.localRotation = Quaternion.Euler(0, 0, 135);
        }

        if (_openBasementDoor)
        {
            _basementDoor.transform.localPosition = Vector3.up*3;
        }
        else
        {
            _basementDoor.transform.localPosition = Vector3.zero;
        }
        if (_correctPositionAxis1)
        {
            _sotanoAxis1.transform.localRotation = Quaternion.Euler(45, 0,0);
        }
        else
        {
            _sotanoAxis1.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        Check();
    }

    public void MoveAxis0()
    {
        if (!_moving0)
        {
            StartCoroutine(CrAxis0());    
        }
    }
    IEnumerator CrAxis0()
    {
        _moving0 = true;
        Quaternion startRotation = Quaternion.Euler(0, 0, 135);
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
        bool previous = _correctPositionAxis0;
        if (_correctPositionAxis0)
        {
            startRotation = Quaternion.Euler(0, 0, 0);
            targetRotation = Quaternion.Euler(0, 0, 135);
        }
        if (previous)
        {
            _correctPositionAxis0 = !_correctPositionAxis0;
            Check();    
        }

        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _sotanoAxis0.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, i / 1f);
            yield return null;
        }
        
        if (!previous)
        {
            _correctPositionAxis0 = !_correctPositionAxis0;
            Check();    
        }

        _sotanoAxis0.transform.localRotation = targetRotation;
        
        GameProgressController.EinsteinBasementAxis0 = _correctPositionAxis0;
        Check();
        _moving0 = false;
    }

    IEnumerator CrAxis1()
    {
        _moving1 = true;
        Quaternion startRotation = Quaternion.identity;
        Quaternion targetRotation = Quaternion.Euler(45, 0, 0);
        if (_correctPositionAxis1)
        {
            startRotation = Quaternion.Euler(45, 0, 0);
            targetRotation = Quaternion.identity;
        }
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _sotanoAxis1.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, i / 1f);
            yield return null;
        }
        _sotanoAxis1.transform.localRotation = targetRotation;
        _correctPositionAxis1 = !_correctPositionAxis1;
        GameProgressController.EinsteinBasementAxis1 = _correctPositionAxis1;
        Check();
        _moving1 = false;
    }

    public void Check()
    {
        if (GameProgressController.GetIsFullRayWorking())
        {

            if (_correctPositionAxis0)
            {
                GameProgressController.EinsteinBasementAxis0 = true;
                if (_correctPositionAxis1)
                {
                    GameProgressController.EinsteinBasementAxis1 = true;
                    _ray.GetComponent<LineRenderer>().SetPosition(0, mirrorPoint.transform.position);

                    _ray.SetActive(true);
                    if (!_openBasementDoor)
                    {
                        StartCoroutine(CrOpenBasementDoor());
                    }
                }
                else
                {
                    GameProgressController.EinsteinBasementAxis1 =false;
                    _ray.SetActive(false);
                }
            }
            else
            {
                GameProgressController.EinsteinBasementAxis0 = false;
                _ray.SetActive(false);
            }
        }
        else
        {
            _ray.SetActive(false);
        }


    }

    IEnumerator CrOpenBasementDoor()
    {
        if (FindObjectOfType<BasementDoorInteractableAttempt>() != null)
        {
            FindObjectOfType<BasementDoorInteractableAttempt>().RemoveInteractable();
        }
        _openBasementDoor = true;
        GameProgressController.SetOpenEinsteinBasementDoor(true);
        FindObjectOfType<BasementLeverAxis0>().RemoveInteractable();
        FindObjectOfType<BasementLeverAxis1>().RemoveInteractable();
        Vector3 startPosition = Vector3.zero;
        Vector3 targetPosition = Vector3.up*3;
        for(float i =0; i< 1f; i += Time.deltaTime)
        {
            yield return null;
            _basementDoor.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, i/1f);
        }
        _basementDoor.transform.localPosition = targetPosition;
    }

    public void MoveAxis1()
    {
        if (!_moving1)
        {
            StartCoroutine(CrAxis1());    
        }
    }

    public void EndDialog()
    {
        PlayerPrefs.SetInt("BasementDialog",1);
    }
}
