using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuenteRotoSceneController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (_player.transform.position.y < -3f)
        {
            GameFlowEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
        }
    }
}
