using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundParent : MonoBehaviour
{
    public static SoundParent soundParent;
    private void Awake()
    {
        if (soundParent == null)
        {
            soundParent = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (soundParent != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
