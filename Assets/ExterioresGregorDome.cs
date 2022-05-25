using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExterioresGregorDome : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _trigger;
    [SerializeField] private DialogueTrigger _trigger2;
    [SerializeField] private GameObject _dome1;
    [SerializeField] private GameObject _dome2;
    [SerializeField] private GameObject _canPlaceHR;
    IEnumerator Start()
    {
        if (!GameProgressController.HeatRejecter)
        {
            yield return new WaitForSeconds(1f);
            _trigger.triggerDialogueEvent(true);
        }
        else
        {
            if (!GameProgressController.PlaceHR)
            {
                _dome1.transform.localRotation = Quaternion.Euler(-10, 0, 0);
                _dome2.transform.localRotation = Quaternion.Euler(-10, 180, 0);
                Instantiate(_canPlaceHR);

            }
        }   
    }

    public void PlaceHR()
    {
        GameProgressController.PlaceHR = true;
        _trigger2.triggerDialogueEvent(true);
    }

    void Update()
    {
        
    }
}
