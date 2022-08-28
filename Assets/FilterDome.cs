using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FilterDome : MonoBehaviour
{

    void Start()
    {
        if(GameProgressController.ESTHR)
        {
            SceneManager.LoadScene("EST_Cupula");
        }
        else
        {
            SceneManager.LoadScene("EST_Cupula HR Espejo");
        }
    }

    void Update()
    {
        
    }
}
