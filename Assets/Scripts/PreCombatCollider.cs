using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreCombatCollider : MonoBehaviour
{

    void Update()
    {
        if (GameProgressController.GetHasTornadoSkill())
        {
            Destroy(gameObject);
        }
    }
}
