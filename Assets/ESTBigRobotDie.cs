using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTBigRobotDie : MonoBehaviour
{
    [SerializeField] private AudioSource _dieSFX;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.15f);
        _dieSFX.Play();
        yield return new WaitForSeconds(14f);
        AudioEvents.muteMusic.Invoke();
        GameEvents.LoadScene.Invoke("FinalCinematic");
    }
}
