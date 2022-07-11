using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPoint : MonoBehaviour
{
    [SerializeField]
    int _point;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.timeSinceLevelLoad > 0.2f)
        {
            GameProgressController.SetCurrentStartPoint(_point);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
