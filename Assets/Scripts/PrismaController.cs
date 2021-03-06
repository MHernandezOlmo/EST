using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaController : MonoBehaviour
{
    [SerializeField] GameObject _solarCanonBall;
    [SerializeField] Transform _targetLeft;
    [SerializeField] Transform _targetRight;
    [SerializeField] Transform _startLeft;
    [SerializeField] Transform _StartRight;
    [SerializeField] SolarPanel _leftSolarPanel, _rightSolarPanel;
    [SerializeField] GameObject _targetPivot;
    [SerializeField] Transform _barrier;
    bool _openBarrier;

    private void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shoot"))
        {
            _targetPivot.transform.LookAt(_targetPivot.transform.position + other.transform.forward);
            GameObject cb0 =  Instantiate(_solarCanonBall, _startLeft.transform.position, Quaternion.identity);
            GameObject cb1 =  Instantiate(_solarCanonBall,_StartRight.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            cb0.transform.LookAt(_targetLeft);
            cb1.transform.LookAt(_targetRight);
        }
    }

    private void Update()
    {
        if (!_openBarrier)
        {
            if(_leftSolarPanel._active && _rightSolarPanel._active)
            {
                _openBarrier= true;
                GameProgressController.EinsteinOpenBarrier = true;
                StartCoroutine(CrOpenBarrier());
            }
        }
    }

    IEnumerator CrOpenBarrier()
    {
        for(float i = 0; i< 1f; i += Time.deltaTime)
        {
            Quaternion startRotation = Quaternion.Euler(0, 0, 0);
            Quaternion targetRotation = Quaternion.Euler(0, 75, 0);
            _barrier.transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, i/1f);
            yield return null;
        }
        _barrier.transform.localRotation = Quaternion.Euler(0, 75, 0);

    }
}
