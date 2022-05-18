using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    private void OnTriggerEnter(Collider other)
    {

        CurrentSceneManager._canJetpack = true;
        _actionButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {

        CurrentSceneManager._canJetpack = false;
        _actionButton.SetActive(false);
    }

}
