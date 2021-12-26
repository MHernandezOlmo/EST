using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationSceneControllers : MonoBehaviour
{

    [SerializeField] GameObject _logosHolder1;
    [SerializeField] GameObject _logosHolder2;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
    }
    void Start()
    {
        StartCoroutine(CrLoadMainMenu());    
    }

    IEnumerator CrLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        yield return FindObjectOfType<TransitionsController>().coFadeToBlack(2f);
        _logosHolder1.SetActive(false);
        yield return new WaitForSeconds(1f);
        _logosHolder2.SetActive(true);
        yield return FindObjectOfType<TransitionsController>().coFadeFromBlack(2f);
        yield return new WaitForSeconds(3f);
        GameEvents.LoadScene.Invoke("PreLevelSelector");
    }
}
