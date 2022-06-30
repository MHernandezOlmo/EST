using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisabler : MonoBehaviour
{
    private FastEnemy[] _fastEnemies;

    private void Start()
    {
        _fastEnemies = FindObjectsOfType<FastEnemy>();
    }

    private void Update()
    {
        foreach(FastEnemy f in _fastEnemies)
        {
            if(Vector3.Distance(f.transform.position, transform.position)> 15)
            {
                f.enabled = false;
            }
            else
            {
                if (!f.enabled)
                {
                    f.enabled = true;
                }
            }
        }
    }
}
