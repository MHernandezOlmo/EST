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
        if (!GameProgressController.EinsteinTowerFirstAdvice)
        {
            StartCoroutine(CrPlayDialog());
        }
        bool isRay = GameProgressController.GetIsFullRayWorking();
        _ray.SetActive(isRay);
        if (GameProgressController.EinsteinUsedPrism)
        {
            _portalOutside.SetActive(true);
        }
    }
    IEnumerator CrPlayDialog()
    {
        yield return new WaitForSeconds(1);
        _dialogTrigger.GetComponent<DialogueTrigger>().triggerDialogueEvent();
        GameProgressController.EinsteinTowerFirstAdvice =true;
    }
    void Update()
    {

    }
}
