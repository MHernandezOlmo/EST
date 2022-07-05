using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    void Start()
    {
        if (GameProgressController.SSTShieldSkill)
        {
            _actionButton.SetActive(true);
        }
    }
}
