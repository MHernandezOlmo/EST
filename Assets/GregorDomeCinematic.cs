using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregorDomeCinematic : MonoBehaviour
{
    [SerializeField] GameObject _dome;   
    [SerializeField] GameObject _dome1;   
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        for(float i = 0; i< 5f; i += Time.deltaTime)
        {
            _dome.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(-83f, 0,0),Quaternion.Euler(-10f, 0,0),i/5f);
            _dome1.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(-97f, 180, 0), Quaternion.Euler(-10f, 180, 0), i / 5f);
            yield return null;
        }
        GameProgressController.GregorDome = true;
        GameEvents.LoadScene.Invoke("Gregor_11_almacen");
    }

    
    void Update()
    {
        
    }
}
