using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaSalaCombate : Interactable
{
    Vector3 _originalPosition;
    public override void Interact()
    {
        StartCoroutine(CrAbrir());
    }

    IEnumerator CrAbrir()
    {
        for (float i = 0; i < 0.25f; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(_originalPosition, _originalPosition + Vector3.up * 4, i / 0.25f);
            yield return null;
        }
        transform.position = _originalPosition + Vector3.up * 4;
        FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        GameProgressController.SetArrivingRoomDoor(true);
    }

    private void Start()
    {
        base.Start();
        _originalPosition = transform.position;
        if (GameProgressController.IsArrivingRoomDoorOpen())
        {
            transform.position = _originalPosition + Vector3.up * 4;
            FindObjectOfType<InteractablesController>().RemoveInteractable(this);
        }

    }
}
