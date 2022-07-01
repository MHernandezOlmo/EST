using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessController : MonoBehaviour
{
    private Animator _darknessAnim;

    void Start()
    {
        CheckGenerator();
    }

    public void CheckGenerator()
    {
        if (GameProgressController.ESTGenerador)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    public void TurnOnLight()
    {
        _darknessAnim = GetComponent<Animator>();
        _darknessAnim.Play("DarknessIn");
    }
}
