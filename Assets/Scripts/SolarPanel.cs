using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    public bool _active;
    Coroutine deactivateCoroutine;
    [SerializeField] Material _green, _red;
    [SerializeField] MeshRenderer _ledIndicator;
    void Start()
    {
        _ledIndicator.material = _red;
        if (GameProgressController.EinsteinOpenBarrier)
        {
            _active = true;
        }
        else
        {
            _active = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shoot"))
        {
            _active = true;
            _ledIndicator.material = _green;
            if (deactivateCoroutine != null)
            {
                StopCoroutine(deactivateCoroutine);
            }
            deactivateCoroutine =StartCoroutine(DeActivate());
        }
    }

    IEnumerator DeActivate()
    {
        yield return new WaitForSeconds(1f);
        _active = false;
        _ledIndicator.material = _red;
    }
}
