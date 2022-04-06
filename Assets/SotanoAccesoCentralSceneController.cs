using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SotanoAccesoCentralSceneController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Start()
    {
        
    }

    void Update()
    {
        if(_player.transform.position.y < 35)
        {
            GameEvents.LoadScene.Invoke("PicDuMidi_7_sotano_acceso_central");
        }
    }
}
