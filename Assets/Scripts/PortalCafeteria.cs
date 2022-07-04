using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCafeteria : MonoBehaviour
{
    bool _canExit;
    [SerializeField] DialogueTrigger trigger;
    [SerializeField] BoxCollider _boxCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (_canExit)
        {
            GameProgressController.SetCurrentStartPoint(0);
            GameEvents.LoadScene.Invoke("PicDuMidi_1_puente_roto");
        }
        else
        {
            FindObjectOfType<SalaPanelesACSceneController>().OpenCloset();
            trigger.triggerDialogueEvent(true);
        }
    }
    void Start()
    {
        _boxCollider.enabled = false;
    }

    void Update()
    {
        if (!_canExit)
        {
            if (GameProgressController.PicDuMidiCoat && GameProgressController.PicDuMidiGlasses)
            {
                _canExit = true;
                _boxCollider.enabled = true;
            }
        }
    }
}
