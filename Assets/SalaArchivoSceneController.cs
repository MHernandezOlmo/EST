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

        yield return null;
        if (GameProgressController.IsCazadoresDeFlaresSolved())
        {
            _block.SetActive(false);
            if (!GameProgressController.GetRecopiledDataAdvice())
            {
                
                _d.triggerDialogueEvent(true);
                yield return new WaitForSeconds(0.2f);
                while (CurrentSceneManager._state != GameStates.Exploration)
                {
                    yield return null;
                }
                
                //CAMBIAR
                GameEvents.ShowScreenText.Invoke("Find the 6 camera pieces");
                GameProgressController.SetRecopiledDataAdvice(true);
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
