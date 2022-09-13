using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingAnimatorCallback : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    public void ActivateBadassBoss()
    {
        _boss.SetActive(true);
        GameProgressController.ESTEnemyCollection = true;
    }
}
