using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkillEnable : MonoBehaviour
{
    [SerializeField]
    GameObject _actionButton;
    void Start()
    {
        if (GameProgressController.GetHasShield())
        {
            _actionButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
