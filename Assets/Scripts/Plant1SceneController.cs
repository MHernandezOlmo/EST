using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant1SceneController : MonoBehaviour
{
    [SerializeField] GameObject _ray;
    [SerializeField] GameObject _realTV, _fakeTV, _realTV2;
    void Start()
    {
        if (GameProgressController.EinsteinUsedPrism)
        {
            _realTV.SetActive(true);
            _realTV2.SetActive(true);
            _fakeTV.SetActive(false);
        }
        _ray.SetActive(GameProgressController.GetIsFullRayWorking());
    }
}
