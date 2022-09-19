using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcuaticasController : MonoBehaviour
{
    [SerializeField] private GameObject _doorTrigger;
    void Start()
    {
        if (FindObjectOfType<CountdownCanvas>() != null)
        {
            _doorTrigger.SetActive(false);
        }
    }
}
