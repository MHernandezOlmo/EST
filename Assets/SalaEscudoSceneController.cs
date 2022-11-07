using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaEscudoSceneController : MonoBehaviour
{
    private Coroutine _crShowMission;
    private void Start()
    {
        if (!GameProgressController.SSTShieldSkill)
        {
            GameEvents.ClearMissionText.Invoke();
        }
    }
    public void Advice()
    {
        GameEvents.ShowScreenText.Invoke("Obtained: Magnetic shield skill");

        _crShowMission = StartCoroutine(CrMission());
        IEnumerator CrMission()
        {
            yield return new WaitForSeconds(5.5f);
            Mission();
        }
    }

    public void Mission()
    {
        if(_crShowMission!= null)
        {
            StopCoroutine(_crShowMission);
        }
        GameEvents.MissionText.Invoke("Destroy the machines and get the AO pieces");
    }
}
