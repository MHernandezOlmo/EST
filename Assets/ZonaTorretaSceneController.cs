using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaTorretaSceneController : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialog;
    

    void Start()
    {
        if (GameProgressController.PicDuMidiToastersAdvice)
        {
            _dialog.gameObject.SetActive(false);
        }
    }

    public void ReadAdvice()
    {
        GameProgressController.PicDuMidiToastersAdvice = true;
        _dialog.gameObject.SetActive(false);
    }
}
