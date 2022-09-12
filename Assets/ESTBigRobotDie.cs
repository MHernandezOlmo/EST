using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTBigRobotDie : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(15f);
        AudioEvents.muteMusic.Invoke();
        GameEvents.LoadScene.Invoke("FinalCinematic");
    }
}
