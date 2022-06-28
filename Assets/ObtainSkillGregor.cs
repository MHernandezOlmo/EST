using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainSkillGregor : MonoBehaviour
{
    public void OnObtainedSkill()
    {
        GameEvents.ShowScreenText.Invoke("New skill: Solar spicules");
    }
}
