using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashRoomSceneController : MonoBehaviour
{
    [SerializeField]
    GameObject _dashInteractable;
    void Start()
    {
        if (GameProgressController.HasDash())
        {
            _dashInteractable.SetActive(false);
        }
    }

}
