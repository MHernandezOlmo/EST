using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant0SceneController : MonoBehaviour
{
    [SerializeField] GameObject _ray;
    [SerializeField] GameObject _dialogTrigger;
    [SerializeField] GameObject _portalOutside;
    void Start()
    {
        if (!GameProgressController.GetEinsteinTowerFirstAdvice())
        {
            StartCoroutine(CrPlayDialog());
        }
        bool isRay = GameProgressController.GetIsFullRayWorking();
        _ray.SetActive(isRay);
        if (GameProgressController.GetUsedPrismEinstein())
        {
            _portalOutside.SetActive(true);
        }
    }
    IEnumerator CrPlayDialog()
    {
        yield return new WaitForSeconds(1);
        _dialogTrigger.GetComponent<DialogueTrigger>().triggerDialogueEvent();
        GameProgressController.SetEinsteinTowerFirstAdvice(true);
    }
    void Update()
    {

    }
}
