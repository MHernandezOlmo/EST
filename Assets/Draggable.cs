using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    bool _moving;
    Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }
    private void OnMouseDown()
    {
        _moving = true;
        transform.localScale = Vector3.one* 0.8f;
    }
    private void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        _moving = false;
        transform.position = Vector3.zero;
        FindObjectOfType<AsociacionElementosController>().CheckPhenomenom();
    }

    void Update()
    {
        if (_moving)
        {
            Vector3 targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            transform.position = targetPosition;
        }
    }
}
