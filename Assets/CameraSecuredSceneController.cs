using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecuredSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger[] _piezesTrigger;
    public enum PiezesToSecure{ Camera, Spectropolarimeter, Filters, AO, HR};
    PiezesToSecure _pieze;
    IEnumerator Start()
    {
        _pieze = (PiezesToSecure)PlayerPrefs.GetInt("PieceToSecure");
        yield return new WaitForSeconds(1f);
        _piezesTrigger[(int)_pieze].triggerDialogueEvent(true);
        GameProgressController.SetCurrentScene("WorldSelector");
    }
    public void End()
    {
        switch (_pieze)
        {
            case PiezesToSecure.Camera:
                GameProgressController.LomnickySolved = true;
                break;
            case PiezesToSecure.Spectropolarimeter:
                GameProgressController.LomnickySolved = true;
                break;
            case PiezesToSecure.Filters:
                GameProgressController.PicDuMidiSolved = true;
                break;
            case PiezesToSecure.AO:
                GameProgressController.SSTSolved= true;
                break;
            case PiezesToSecure.HR:
                GameProgressController.GregorFinished= true;
                break;
        }

        GameEvents.LoadScene.Invoke("WorldSelector");
    }
    void Update()
    {
        
    }
}
