using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField]
    Material _green;
    [SerializeField]
    int materialIndex;
    [SerializeField] int _buttonIndex;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Material[] matArray = GetComponent<MeshRenderer>().materials;
        matArray[materialIndex] = _green;
        GetComponent<MeshRenderer>().materials = matArray;
        FindObjectOfType<SalaPiezaD>().SetButton(_buttonIndex);
    }
    void Update()
    {
        
    }
}
