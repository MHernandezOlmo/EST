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
        GameProgressController.SetCurrentStartPoint(_point);

//        PlayerPrefs.SetInt("PreviousPoint", _point);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
