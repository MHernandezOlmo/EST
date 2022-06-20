using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLabInteractable : Interactable
{
    [SerializeField] private GameObject _door;
    private bool _isOpen;


    public override void Interact()
    {
        if (!_isOpen)
        {
            StartCoroutine(CrOpenDoor());
            _isOpen = true;
        }
    }

    IEnumerator CrOpenDoor()
    {
        for(float i = 0; i< 1f; i += Time.deltaTime)
        {
            _door.transform.localRotation = Quaternion.Euler(Vector3.Lerp(Vector3.zero, Vector3.up * -90, i));
            yield return null;
        }
        _door.transform.localRotation = Quaternion.Euler(Vector3.up * -90);
    }
}
