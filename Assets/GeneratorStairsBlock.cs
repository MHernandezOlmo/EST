using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorStairsBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!GameProgressController.ESTGenerador)
        {
            gameObject.SetActive(false);
        }
    }
}
