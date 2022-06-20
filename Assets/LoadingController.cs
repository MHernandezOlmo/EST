using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    private void Awake()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(this);
        GameEvents.OnLoadSceneMoment.AddListener(OnSceneLoad);
    }

    void OnSceneLoad(string sceneName)
    {
        if(sceneName == "MainMenu")
        {
            StartCoroutine(CrCheckSceneLoad());
            IEnumerator CrCheckSceneLoad()
            {
                transform.GetChild(0).gameObject.SetActive(true);
                while (!SceneManager.GetActiveScene().isLoaded)
                {
                    yield return null;
                }
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
