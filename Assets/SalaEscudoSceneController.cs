using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaEscudoSceneController : MonoBehaviour
{
    public void Advice()
    {
        GameEvents.ShowScreenText.Invoke("Obtained: Magnetic shield skill");
    }
}
