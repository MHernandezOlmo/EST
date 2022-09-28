using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinsteinStairsBlock : MonoBehaviour
{
    private bool _shown;
    void Start()
    {
        if (GameProgressController.EinsteinBasementDialog)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_shown)
        {
            GameEvents.ShowScreenText.Invoke("Go to the basement first");
            StartCoroutine(CrCooldown());
        }
    }

    IEnumerator CrCooldown()
    {
        _shown = true;
        yield return new WaitForSeconds(3f);
        _shown = false;
    }
}
