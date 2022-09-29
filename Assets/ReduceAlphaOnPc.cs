using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReduceAlphaOnPc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE_WIN

        GetComponent<Image>().color = new Color(0, 0, 0, 0);

#endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
