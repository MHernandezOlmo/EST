using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaPrincipalCameraTrigger : MonoBehaviour
{
    [SerializeField]
    int _camera;
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SalaPrincipalSceneController>().ChangeCamera(_camera);
    }
}
