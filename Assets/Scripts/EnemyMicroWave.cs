using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMicroWave : MonoBehaviour
{
    Vector3 _startPosition;
    bool canBeSeen;
    [SerializeField] Material _blueFresnel;
    void Start()
    {
        if (GameProgressController.GetHasAO())
        {
            canBeSeen = true;
        }
        if (!canBeSeen)
        {
            SkinnedMeshRenderer sk = GetComponentInChildren<SkinnedMeshRenderer>();
            for(int i =0; i<sk.materials.Length; i++)
            {
                sk.materials[i] = _blueFresnel;
            }
        }
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!canBeSeen)
        //{
        //    transform.position = _startPosition + Vector3.one * Random.Range(-0.5f, 0.5f);
        //}
    }
}
