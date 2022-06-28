using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExterioresGregorBisSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialogueTriggerCleanGarden;
    [SerializeField] private CinemachineVirtualCamera _finalCamera, _startCamera;
    [SerializeField] private MeshRenderer _tower;
    [SerializeField] private Material _white;
    [SerializeField] private GameObject _VTTDoor;
    [SerializeField] SceneChangeInteractable _stairsInteractable;
    [SerializeField] GameObject _stairsInteractable2;
    [SerializeField] GameObject _skillEnable, _cleanParticles;
    int neededKills;
    IEnumerator Start()
    {
        neededKills = 4;
        if (GameProgressController.PaintTower)
        {
            _tower.material = _white;
            _cleanParticles.SetActive(true);
            yield return new WaitForSeconds(2f);
            _finalCamera.Priority = 30;
            _VTTDoor.SetActive(true);
            Instantiate(_stairsInteractable2);
            _stairsInteractable.RemoveInteractable();        
        }
        else
        {
            yield return new WaitForSeconds(1f);
            _startCamera.Priority = 0;
            yield return new WaitForSeconds(1f);
            _dialogueTriggerCleanGarden.triggerDialogueEvent(true);
        }

        if (GameProgressController.Jetpack)
        {
            _skillEnable.SetActive(true);
        }
        
    }

    public void RestoreCam()
    {
        _finalCamera.Priority = 30;
    }

    public void LoadTorre()
    {
        GameEvents.LoadScene.Invoke("PintaTorre");
    }
    public void Kill()
    {
        neededKills--;
        if (neededKills == 0)
        {
            GameEvents.LoadScene.Invoke("WorldSelector");
        }
    }
    void Update()
    {
        
    }
}
