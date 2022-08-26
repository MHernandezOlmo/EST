using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinArchivoSceneController : MonoBehaviour
{
    EinsteinPCArchivo _interactablePC;
    [SerializeField] private DialogueTrigger _trigger;
    private void Start()
    {
        _interactablePC = FindObjectOfType<EinsteinPCArchivo>();
        if(!(GameProgressController.EinsteinNeedPrism && !GameProgressController.EinsteinHasPrism))
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(_interactablePC);
            Destroy(_interactablePC.transform.parent.gameObject);
        }
        StartCoroutine(CrReceiveSplitter());
    }
    IEnumerator CrReceiveSplitter()
    {
        if(PlayerPrefs.GetInt("ReceiveSplitter") == 1)
        {
            PlayerPrefs.SetInt("ReceiveSplitter", 0);
            yield return new WaitForSeconds(1f);
            _trigger.triggerDialogueEvent(true);
        }
    }
    public void Advice()
    {
        GameEvents.ShowScreenText.Invoke("Obtained beam-splitter");
    }
    public void LoadLomnicky()
    {
        GameEvents.LoadScene.Invoke("Lomnicky_12_Sala Secreta 1");
    }
}
