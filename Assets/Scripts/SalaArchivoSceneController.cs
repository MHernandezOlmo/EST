using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaArchivoSceneController : MonoBehaviour
{

    MovementController _player;
    [SerializeField]
    DialogueTrigger _d;
    [SerializeField]
    GameObject _block;
    IEnumerator Start()
    {
        _player = FindObjectOfType<MovementController>();

        if (GameProgressController.LomnickyPuzzleFlareHunters)
        {
            _block.SetActive(false);
            if (!GameProgressController.LomnickyRecopiledDataAdvice)
            {
                yield return new WaitForSeconds(1f);
                _d.triggerDialogueEvent(true);
                GameProgressController.LomnickyRecopiledDataAdvice=true;
            }
        }
    }

    public void FindCameraAdvice()
    {
        GameEvents.ShowScreenText.Invoke("Find the 6 camera parts");
        GameEvents.MissionText.Invoke("Find all the camera pieces");
    }
}
