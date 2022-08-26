using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorJeanRoc : MonoBehaviour
{
    [SerializeField]
    GameObject _tapa;
    [SerializeField]
    GameObject uncoverInteractable;
    [SerializeField] private DialogueTrigger _dialog;
    [SerializeField] private GameObject _stairs;
    private void Awake()
    {
        if (!GameProgressController.PicDuMidiPuzzleCoronagraph)
        {
            _stairs.gameObject.SetActive(false);
        }
        if (GameProgressController.PicDuMidiUncoveredJeanRoch)
        {
            uncoverInteractable.gameObject.SetActive(false);
            _tapa.transform.localPosition = new Vector3(-237.19f, -6.05f, 42.825f);
            _tapa.transform.localRotation = Quaternion.Euler(0.235f,51.179f,-6.008f);

            if (!GameProgressController.TelescopeReady)
            {
                GameProgressController.TelescopeReady = true;
                StartCoroutine(CrTriggerDialog());
            }
        }
    }

    IEnumerator CrTriggerDialog()
    {
        
        yield return new WaitForSeconds(1);
        _dialog.triggerDialogueEvent(true);
    }
}
