using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChildController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(gameObject.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent == gameObject.transform)
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
