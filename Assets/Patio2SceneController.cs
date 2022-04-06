using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patio2SceneController : MonoBehaviour
{

    [SerializeField] private DialogueTrigger _dialog;

    void Start()
    {
        if (GameProgressController.CoronalAdvice)
        {
            _dialog.gameObject.SetActive(false);
        }
    }

    public void ReadAdvice()
    {
        GameProgressController.CoronalAdvice = true;
        _dialog.gameObject.SetActive(false);
    }
    public void ContactUV()
    {
        GameEvents.ShowScreenText.Invoke("Find a way to contact UV");
        GameProgressController.NeedContactUV = true;

    }
}
