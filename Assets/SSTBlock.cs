using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTBlock : MonoBehaviour
{
    void Start()
    {
        if (GameProgressController.SSTPuzzlePairs)
        {
            Destroy(gameObject);
        }
    }
}
