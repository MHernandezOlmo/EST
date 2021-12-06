using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUIPoolController : MonoBehaviour
{
    [SerializeField]
    Image[] _interactableImage;
    InteractablesController _interactablesController;
    Camera _camera;
    MovementController _playerController;
    int _previousInteractable;
    int _selectedInteractable;

    private void Start()
    {
        _camera = Camera.main;
        _previousInteractable = -1;
        _interactablesController = FindObjectOfType<InteractablesController>();
        _playerController = FindObjectOfType<MovementController>();
    }
    
    private void LateUpdate()
    {
        List<Interactable> ints = _interactablesController.GetAllInteractables();
        if(ints == null)
        {
            return;
        }
        float mindistance = 2f;
        int targetInteractable = -1;
        for (int i = 0; i< ints.Count; i++)
        {
            float newDist = Vector3.Distance(ints[i].transform.position, _playerController.transform.position);

            if (newDist < mindistance)
            {
                mindistance = newDist;
                targetInteractable = i;
            }
            _interactableImage[i].gameObject.SetActive(true);
            _interactableImage[i].rectTransform.position =  _camera.WorldToScreenPoint(ints[i].GetInteractableMarker().position);
        }
        for(int i =ints.Count; i< _interactableImage.Length;i++)
        {
            _interactableImage[i].gameObject.SetActive(false);
        }
        if (targetInteractable >=0)
        {
            _selectedInteractable = targetInteractable;
        }
        else
        {
            _selectedInteractable = -1;
        }

        if (_previousInteractable != _selectedInteractable)
        {
            if (_selectedInteractable >= 0)
            {
                StartCoroutine(ShowInteractable(_selectedInteractable));
            }
            
            if (_previousInteractable >= 0)
            {
                StartCoroutine(HideInteractable(_previousInteractable));
            }
        }
        _previousInteractable = _selectedInteractable;
    }
    public int GetSelectedInteractable()
    {
        return _selectedInteractable;
    }

    IEnumerator ShowInteractable(int interact)
    {
        //_interactablesController.SetCurrentInteractable(interact);
        Image _glass = _interactableImage[interact].transform.GetChild(0).GetComponent<Image>();
        for(float i = 0;i< 0.5f; i += Time.deltaTime)
        {
            _glass.rectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i/0.25f);
            yield return null;
        }
        _glass.rectTransform.localScale = Vector3.one;
    }

    IEnumerator HideInteractable(int interact)
    {
        //_interactablesController.SetCurrentInteractable(-1);
        Image _glass = _interactableImage[interact].transform.GetChild(0).GetComponent<Image>();
        for (float i = 0; i < 0.5f; i += Time.deltaTime)
        {
            _glass.rectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero,i / 0.25f);
            yield return null;
        }
        _glass.rectTransform.localScale = Vector3.zero;
    }
}
