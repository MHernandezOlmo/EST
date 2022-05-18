using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExterioresGregorBisSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialogueTriggerCleanGarden;
    [SerializeField] private CinemachineVirtualCamera _finalCamera;
    [SerializeField] private MeshRenderer _tower;
    [SerializeField] private Material _white;
    [SerializeField] private GameObject _VTTDoor;
    IEnumerator Start()
    {
        if (GameProgressController.PaintTower)
        {
            _tower.material = _white;
            _finalCamera.Priority = 30;
            _VTTDoor.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(1f);
            _dialogueTriggerCleanGarden.triggerDialogueEvent(true);
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
    
    void Update()
    {
        
    }
}
