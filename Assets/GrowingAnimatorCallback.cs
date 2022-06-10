using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingAnimatorCallback : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    void Start()
    {
        
    }

    public void ActivateBadassBoss()
    {
        _boss.SetActive(true);
    }

}
