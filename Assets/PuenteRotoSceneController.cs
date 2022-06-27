using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuenteRotoSceneController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _minHeight;

    void Update()
    {
        if (_player.transform.position.y < _minHeight)
        {
            GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
        }
    }
}
