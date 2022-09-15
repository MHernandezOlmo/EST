using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    [SerializeField] private bool _isBridge, _isLaser;

    private void OnTriggerEnter(Collider other)
    {
        if (_isBridge && !GameProgressController.PicDuMidiDashSkill)
        {
            GameEvents.ShowScreenText.Invoke("Need the skill to cross");
            return;
        }
        if (_isLaser && !GameProgressController.GregorJetpackSkill)
        {
            GameEvents.ShowScreenText.Invoke("Need the skill to cross");
            return;
        }
        _actionButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _actionButton.SetActive(false);
    }
}
