using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinDomeSceneController : MonoBehaviour
{
    [SerializeField] GameObject _dome;
    bool _isDomeOpen;
    [SerializeField] Color _bright;
    [SerializeField] Color _dark;
    [SerializeField] GameObject _axis0;
    [SerializeField] GameObject _axis1;
    [SerializeField] GameObject _axis2;
    [SerializeField] GameObject _domeLeverInteractable;
    [SerializeField] GameObject _domeLeverTransform;
    [SerializeField] GameObject _firstRay;
    [SerializeField] GameObject _secondRay;

    [SerializeField] GameObject _domeLeverAxis0;
    [SerializeField] GameObject _domeLeverAxis1;
    [SerializeField] GameObject _domeLeverAxis2;
    [SerializeField] GameObject _mirrorInteractable;
    [SerializeField] private Material _materialWhite;
    [SerializeField] private Material _materialBrokenWhite;
    [SerializeField] public GameObject _mirror;
    bool _axis0CorrectPosition;
    bool _axis1CorrectPosition;
    bool _axis2CorrectPosition;
    [SerializeField] DialogueTrigger _domeMirrorDialogue;
    [SerializeField] DialogueTrigger _firstDialogueDome;
    [SerializeField] DialogueTrigger _placedMirrorDome;
    [SerializeField] DialogueTrigger _celostateWorking;
    private bool _movinAxis0, _movingAxis1, _movingAxis2;
    [SerializeField] private GameObject _middleHole;
    [SerializeField] private GameObject _skyRay;
    IEnumerator Start()
    {
        CurrentSceneManager._skillEnabled = false;
        _isDomeOpen = GameProgressController.EinsteinDomeOpen;
        if (GameProgressController.EinsteinPlacedMirror)
        {
            _mirror.GetComponent<MeshRenderer>().materials[0] = _materialWhite; 
            _domeLeverAxis0.SetActive(true);
            _domeLeverAxis1.SetActive(true);
            _domeLeverAxis2.SetActive(true);
        }
        else
        {
            if (GameProgressController.EinsteinHasMirror)
            {
                _mirrorInteractable.SetActive(true);
            }
        }

        _axis0CorrectPosition = GameProgressController.EinsteinDomeAxis0;
        _axis1CorrectPosition = GameProgressController.EinsteinDomeAxis1;
        _axis2CorrectPosition = GameProgressController.EinsteinDomeAxis2;
        if (_axis0CorrectPosition)
        {
            _axis0.transform.localRotation = Quaternion.identity;
        }
        else
        {
            _axis0.transform.localRotation = Quaternion.Euler(0, 250, 0);
        }
        if (_axis1CorrectPosition)
        {
            _axis1.transform.localRotation = Quaternion.identity;
        }
        else
        {
            _axis1.transform.localRotation = Quaternion.Euler(0, 125, 0);
        }
        if (_axis2CorrectPosition)
        {
            _axis2.transform.localRotation = Quaternion.Euler(0, 0, 50);
        }
        else
        {
            _axis2.transform.localRotation = Quaternion.Euler(0, 0, 175);
        }

        
        if (_isDomeOpen)
        {
            _firstDialogueDome.gameObject.SetActive(false);
            _dome.transform.rotation = Quaternion.identity;
            RenderSettings.ambientLight = _bright;
            _domeLeverTransform.transform.localRotation = Quaternion.Euler(135,0, 0);
            FindObjectOfType<InteractablesController>().RemoveInteractable(_domeLeverInteractable.GetComponentInChildren<DomeLever>());
            _domeLeverInteractable.SetActive(false);
        }
        else
        {
            _dome.transform.rotation = Quaternion.Euler(0,22f,0);
            RenderSettings.ambientLight = _dark;
            _domeLeverTransform.transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        yield return null;

        Check();
    }


    public void PlaceMirror()
    {
        _placedMirrorDome.triggerDialogueEvent();
        _mirror.GetComponent<Animator>().SetTrigger("Change");
        _domeLeverAxis0.SetActive(true);
        _domeLeverAxis1.SetActive(true);
        _domeLeverAxis2.SetActive(true);
        GameProgressController.EinsteinPlacedMirror = true;
    }
    public void OpenDome()
    {
        if (!_isDomeOpen)
        {
            _isDomeOpen = true;
            GameProgressController.EinsteinDomeOpen = true;
            GameProgressController.EinsteinNeedMirror = true;
            StartCoroutine(CrOpenDome());
        }
    }
    public void MoveAxis0()
    {
        if (!_movinAxis0)
        {
            StartCoroutine(CrAxis0());    
        }
    }
    IEnumerator CrAxis0()
    {
        _movinAxis0 = true;
        Quaternion startRotation = Quaternion.Euler(0, 250, 0);
        Quaternion targetRotation = Quaternion.identity;
        bool _previousAxixPosition0 = _axis0CorrectPosition; 
        if (_axis0CorrectPosition)
        {
            startRotation = Quaternion.identity;
            targetRotation = Quaternion.Euler(0, 250, 0);
        }

        if (_previousAxixPosition0)
        {
            _axis0CorrectPosition = !_axis0CorrectPosition;
            Check();    
        }
        
        for(float i = 0; i< 1f; i += Time.deltaTime)
        {
            _axis0.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, i/1f);
            yield return null;
        }
        _axis0.transform.localRotation = targetRotation;

        if (!_previousAxixPosition0)
        {
            _axis0CorrectPosition = !_axis0CorrectPosition;
            Check();    
        }
        
        _movinAxis0 = false;
    }
    public void MoveAxis1()
    {
        if (!_movingAxis1)
        {
            StartCoroutine(CrAxis1());    
        }
    }
    IEnumerator CrAxis1()
    {
        _movingAxis1 = true;
        Quaternion startRotation = Quaternion.Euler(0, 125, 0);
        Quaternion targetRotation = Quaternion.identity;
        bool previous = _axis1CorrectPosition;
        if (_axis1CorrectPosition)
        {
            startRotation = Quaternion.identity;
            targetRotation = Quaternion.Euler(0, 125, 0);
        }

        if (previous)
        {
            _axis1CorrectPosition = !_axis1CorrectPosition;
            Check();    
        }

        
        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _axis1.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, i / 1f);
            yield return null;
        }
        
        _axis1.transform.localRotation = targetRotation;
        if (!previous)
        {
            _axis1CorrectPosition = !_axis1CorrectPosition;
            Check();    
        }
        _movingAxis1 = false;
    }
    public void Check()
    {
        if (_axis0CorrectPosition)
        {
            GameProgressController.EinsteinDomeAxis0 = true;
            if (_axis1CorrectPosition)
            {
                GameProgressController.EinsteinDomeAxis1 = true;
                _firstRay.GetComponent<LineRenderer>().SetPosition(0, _firstRay.transform.position);
                _firstRay.GetComponent<LineRenderer>().SetPosition(1, _secondRay.transform.position);
                _firstRay.SetActive(true);
                _skyRay.GetComponent<LineRenderer>().SetPosition(0, _skyRay.transform.position);
                _skyRay.GetComponent<LineRenderer>().SetPosition(1, _firstRay.transform.position);
                _skyRay.SetActive(true);
                if (_axis2CorrectPosition)
                {
                    _secondRay.GetComponent<LineRenderer>().SetPosition(0, _secondRay.transform.position);
                    _secondRay.GetComponent<LineRenderer>().SetPosition(1, _middleHole.transform.position);
                    _secondRay.SetActive(true);
                    GameProgressController.EinsteinDomeAxis2 = true;
                    _celostateWorking.triggerDialogueEvent(true);
                }
                else
                {
                    GameProgressController.EinsteinDomeAxis2 = false;
                    _secondRay.SetActive(false);
                }
            }
            else
            {
                _firstRay.SetActive(false);
                _skyRay.SetActive(false);
                _secondRay.SetActive(false);

                GameProgressController.EinsteinDomeAxis1 = false;
            }

        }
        else
        {
            GameProgressController.EinsteinDomeAxis0 = false;
            _firstRay.SetActive(false);
            _skyRay.SetActive(false);

            _secondRay.SetActive(false);

        }
    }
    public void MoveAxis2()
    {
        if (!_movingAxis2)
        {
            StartCoroutine(CrAxis2());    
        }
    }
    IEnumerator CrAxis2()
    {
        _movingAxis2 = true;
        Quaternion startRotation = Quaternion.Euler(0, 0, 175);
        Quaternion targetRotation = Quaternion.Euler(0, 0, 50);
        bool previous = _axis2CorrectPosition; 
        if (_axis2CorrectPosition)
        {
             startRotation = Quaternion.Euler(0, 0, 50);
             targetRotation = Quaternion.Euler(0, 0, 175);
        }
        
        if (previous)
        {
            _axis2CorrectPosition = !_axis2CorrectPosition;
            Check();    
        }

        for (float i = 0; i < 1f; i += Time.deltaTime)
        {
            _axis2.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, i / 1f);
            yield return null;
        }
        
        if (!previous)
        {
            _axis2CorrectPosition = !_axis2CorrectPosition;
            Check();    
        }

        _axis2.transform.localRotation = targetRotation;
        Check();
        _movingAxis2 = false;
    }
    IEnumerator CrOpenDome()
    {
        Quaternion startRotation = Quaternion.Euler(0, 22f, 0);
        Quaternion targetRotation = Quaternion.identity;
        
        for (float i =0; i< 2f; i += Time.deltaTime)
        {
            RenderSettings.ambientLight = Color.Lerp(_dark, _bright, i/2f);
            _dome.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, i/2f);
            yield return null;
        }
        _dome.transform.rotation = Quaternion.identity;
        _domeMirrorDialogue.triggerDialogueEvent(true);
    }
}
