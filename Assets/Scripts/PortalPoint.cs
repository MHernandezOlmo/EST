using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPoint : MonoBehaviour
{
    [SerializeField]
    int _point;

    private void OnTriggerEnter(Collider other)
    {
        if (Time.timeSinceLevelLoad > 0.2f)
        {
            GameProgressController.SetCurrentStartPoint(_point);
        }
    }
}
