using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzoteaCameraTrigger : MonoBehaviour
{
    [SerializeField]
    int _camera;
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SalaAzoteaSceneController>().ChangeCamera(_camera);
    }
}
