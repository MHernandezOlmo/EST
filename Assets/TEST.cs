using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CRTest());
    }
    IEnumerator CRTest()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(5);
        print(1);
        Time.timeScale = 10f;
        yield return new WaitForSeconds(5);
        print(2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
