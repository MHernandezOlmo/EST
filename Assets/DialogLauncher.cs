using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLauncher : MonoBehaviour
{
    private bool _hasBeenLaunched;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !_hasBeenLaunched)
        {
            _hasBeenLaunched = true;
            FindObjectOfType<ESTExteriorsSceneController>().LaunchDialog();
        }
    }
}
