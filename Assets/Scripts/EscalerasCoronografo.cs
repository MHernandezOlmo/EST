using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasCoronografo : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _trigger;
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

    private void Awake()
    {
        if (GameProgressController.Parejas)
        {
            StartCoroutine(CrAdvice());
        }
    }

    IEnumerator CrAdvice()
    {
        yield return new WaitForSeconds(1f);
        _trigger.triggerDialogueEvent(true);
    }
}
