using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLabInteractable : Interactable
{
    [SerializeField] private GameObject _door;
    private void Awake()
    {
        
    }
    public override void Interact()
    {
        StartCoroutine(CrOpenDoor());
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
