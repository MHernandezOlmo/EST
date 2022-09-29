using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizeOnPC : MonoBehaviour
{
    
    void Start()
    {
#if UNITY_STANDALONE_WIN

        GetComponent<RectTransform>().sizeDelta = new Vector2(3000, 1000);

#endif    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
