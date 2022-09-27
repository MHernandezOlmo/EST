using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSceneController : MonoBehaviour
{
    [SerializeField] private RectTransform _rt;
    [SerializeField] private GameObject _arrow;
    bool _load;

    public void Skip()
    {
        GameEvents.LoadScene.Invoke("MainMenu");
    }

    public void OnScroll(Vector2 value)
    {
        if (value.y < 0.9f)
        {
            _arrow.SetActive(false);
        }
    }
}
