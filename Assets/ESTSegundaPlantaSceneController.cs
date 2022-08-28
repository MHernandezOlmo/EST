using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTSegundaPlantaSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _blockDialog;
    [SerializeField] private GameObject _sceneChanger;

    void Start()
    {
        if (!GameProgressController.ESTDomeOpen)
        {
            _blockDialog.gameObject.SetActive(true);
            _sceneChanger.gameObject.SetActive(false);
        }
        else
        {
            _blockDialog.gameObject.SetActive(false);
            _sceneChanger.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
