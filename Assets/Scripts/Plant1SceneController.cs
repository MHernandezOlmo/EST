using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant1SceneController : MonoBehaviour
{
    [SerializeField] GameObject _ray;
    void Start()
    {
        _ray.SetActive(GameProgressController.GetIsFullRayWorking());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
