using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCafeteria : MonoBehaviour
{
    bool _canExit;
    [SerializeField] DialogueTrigger trigger;
    [SerializeField] BoxCollider _boxCollider;
    [SerializeField] private int portal;
    private void OnTriggerEnter(Collider other)
    {
        if (Time.timeSinceLevelLoad < 0.2f)
        {
            return;
        }
        if (_canExit)
        {
            if (portal == 0)
            {
                GameProgressController.SetCurrentStartPoint(0);
                GameEvents.LoadScene.Invoke("PicDuMidi_1_puente_roto");
            }
            else
            {
                GameProgressController.SetCurrentStartPoint(0);
                GameEvents.LoadScene.Invoke("PicDuMidi_2_terraza_antena");
            }
            
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
