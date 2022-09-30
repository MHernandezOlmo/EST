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
    [SerializeField] SceneChangeInteractable _stairsPuzzleInteractable;
    [SerializeField] GameObject _stairsInteractable2;
    [SerializeField] GameObject _skillEnable, _cleanParticles;
    [SerializeField] GameObject _scenePortalVTT;
    int neededKills;
    IEnumerator Start()
    {
        neededKills = 4;
        if (GameProgressController.GregorPuzzlePaintTower)
        {
            _scenePortalVTT.gameObject.SetActive(true);
            _tower.material = _white;
            Instantiate(_stairsInteractable2);
            _stairsPuzzleInteractable.RemoveInteractable();
            if (!GameProgressController.GregorHasHeatRejecter)
            {
                _cleanParticles.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
            _finalCamera.Priority = 30;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            _startCamera.Priority = 0;
            yield return new WaitForSeconds(1f);
            _dialogueTriggerCleanGarden.triggerDialogueEvent(true);
        }
        if (GameProgressController.GregorJetpackSkill)
        {
            _skillEnable.SetActive(true);
        }
        if (GameProgressController.GregorPlacedHeatRejecter)
        {
            GameEvents.ShowScreenText.Invoke("Remaining threads: " + neededKills);
        }
    }

    public void StartPaintMission()
    {
        GameEvents.ShowScreenText.Invoke("Climb the ladder and paint the tower");
    }

    public void RestoreCam()
    {
        _finalCamera.Priority = 30;
    }
    public void LoadTorre()
    {
        GameEvents.LoadScene.Invoke("GregorPuzzlePaintTower");
    }
    public void Kill()
    {
        neededKills--;
        GameEvents.ShowScreenText.Invoke("Remaining threads: " + neededKills);
        if (neededKills == 0)
        {
            GameEvents.ClearMissionText.Invoke();
            PlayerPrefs.SetInt("PieceToSecure", 3);
            GameEvents.LoadScene.Invoke("SecurePiece");
        }
    }

}
