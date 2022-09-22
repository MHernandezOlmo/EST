using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSceneController : MonoBehaviour
{
    [SerializeField] private RectTransform _rt;
    bool _load;
    void Start()
    {
    }

    public void Skip()
    {
        GameEvents.LoadScene.Invoke("MainMenu");
    }
    void Update()
    {
        
        _rt.anchoredPosition +=(Vector2)Vector3.up * 120 * Time.deltaTime;
        if(!_load && Time.timeSinceLevelLoad > 60)
        {
            _load = true;
            Skip();
        }
    }
}
