using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinArchivoSceneController : MonoBehaviour
{
    EinsteinPCArchivo _interactablePC;
    private void Start()
    {
        _interactablePC = FindObjectOfType<EinsteinPCArchivo>();
        if(!(GameProgressController.GetNeedsPrismEinstein() && !GameProgressController.GetHasPrismEinstein()))
        {
            FindObjectOfType<InteractablesController>().RemoveInteractable(_interactablePC);
            Destroy(_interactablePC.transform.parent.gameObject);
        }
    }

    public void LoadLomnicky()
    {
        
        GameEvents.LoadScene.Invoke("Lomnicky_12_Sala Secreta 1");
    }
}
