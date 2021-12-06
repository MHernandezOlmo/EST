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
        if (!_canExit)
        {
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
            if(GameProgressController.GetHasAbrigo() && GameProgressController.GetHasGlasses())
            {
                _canExit = true;
                _boxCollider.enabled = true;
            }
        }
    }
}
