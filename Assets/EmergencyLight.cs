using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    [SerializeField]
    Material _emergencyLightMaterial;
    float _elapsedTime;
    float _intermitentLightTime =1f;
    bool rojo;
    bool _setted;
    [SerializeField] Light _light;
    void Start()
    {
                
    }

    void Update()
    {
        if (!GameProgressController.IsCeilingClosed())
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > 1f)
            {
                _elapsedTime = 0f;
                if (rojo)
                {
                    _emergencyLightMaterial.color = Color.white;
                    _light.gameObject.SetActive(false);
                }
                else
                {
                    _light.gameObject.SetActive(true);
                    _emergencyLightMaterial.color = Color.red;
                }
                rojo = !rojo;
            }
        }
        else
        {
            if (!_setted)
            {
                _light.gameObject.SetActive(false);
                _setted = true;
                _emergencyLightMaterial.color = Color.green;
            }
        }
    }
}
