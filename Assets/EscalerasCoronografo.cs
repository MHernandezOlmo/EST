using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasCoronografo : MonoBehaviour
{
    public void DownStairs()
    {
        StartCoroutine(CrDownStairs());
    }

    IEnumerator CrDownStairs()
    {
        for(float i = 0; i< 3f; i += Time.deltaTime)
        {
            transform.position = new Vector3(transform.position.x, 5 - (5 * i / 3f), transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
