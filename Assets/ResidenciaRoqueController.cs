using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidenciaRoqueController : MonoBehaviour
{
    [SerializeField] DialogueTrigger _dialogTrigger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        _dialogTrigger.triggerDialogueEvent(true);
    }
    public void LoadExteriors()
    {
        GameProgressController.SetCurrentStartPoint(0);

        GameEvents.LoadScene.Invoke("SST_1_exterior");
    }

}
