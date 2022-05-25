using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaGregorSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _combatTrigger;
    [SerializeField] private GameObject[] _enemies;
    void Start()
    {
        if(!GameProgressController.Jetpack)
        {
            _combatTrigger.gameObject.SetActive(false); 
        }
        else
        {
            foreach(GameObject g  in _enemies)
            {
                g.SetActive(false);
            }
            _combatTrigger.gameObject.SetActive(true);

        }
    }

    void Update()
    {
        
    }
}
