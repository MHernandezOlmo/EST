using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAdvice : MonoBehaviour
{
    private void Start()
    {
        if (GameProgressController.PicDuMidiDashSkill)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.ShowScreenText.Invoke("Find the skill to cross");
        }
    }
}
