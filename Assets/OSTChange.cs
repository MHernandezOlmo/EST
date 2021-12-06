using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OSTChange : MonoBehaviour
{
    [SerializeField] private string newSong;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Cinematic")
        {
            FindObjectOfType<OSTController>()?.DimMusic();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "WorldSelector")
            {
                FindObjectOfType<OSTController>()?.UnDimMusic();
            }
            else
            {
                FindObjectOfType<OSTController>()?.ChangeSong(newSong);        
            }
        }    
    }

    void Update()
    {
        
    }
}
