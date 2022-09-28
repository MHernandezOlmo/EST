using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant0SceneController : MonoBehaviour
{
    [SerializeField] GameObject _ray;
    [SerializeField] GameObject _dialogTrigger;
    [SerializeField] GameObject _portalOutside;
    [SerializeField] GameObject _realTV;
    [SerializeField] GameObject[] _fakeTVs;

    void Start()
    {
        if (GameProgressController.EinsteinUsedPrism)
        {
            _realTV.SetActive(false);
            _fakeTVs[0].SetActive(true);
            _fakeTVs[1].SetActive(true);
        }
        if (!GameProgressController.EinsteinTowerFirstAdvice)
        {
            GameEvents.ClearMissionText.Invoke();
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
