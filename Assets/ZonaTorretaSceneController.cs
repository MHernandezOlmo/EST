using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaTorretaSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialog;
    

    void Start()
    {
        GameProgressController.ToastersAdvice = false;
        if (GameProgressController.ToastersAdvice)
        {
            _dialog.gameObject.SetActive(false);
        }
    }

    public void ReadAdvice()
    {
        GameProgressController.ToastersAdvice = true;
        _dialog.gameObject.SetActive(false);
    }
}
