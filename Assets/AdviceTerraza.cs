using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceTerraza : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.MissionText.Invoke("Enter CLIMSO coronagraph");
            Destroy(gameObject);
        }
    }
}
