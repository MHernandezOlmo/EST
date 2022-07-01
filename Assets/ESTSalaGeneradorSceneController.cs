using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTSalaGeneradorSceneController : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<BadassAttack>().ContinuosAttack();
    }
}
