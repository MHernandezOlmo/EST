using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPPool : MonoBehaviour
{
    [SerializeField] RectTransform[] _hpBarRTs;
    [SerializeField] HPBar[] _hpBars;

    [SerializeField] RectTransform _playerHPBarRT;
    [SerializeField] HPBar _playerHPBar;
    
    void Start()
    {
        foreach(RectTransform rt in _hpBarRTs)
        {
            rt.gameObject.SetActive(false);
        }
    }

    public void AddBar(EnemyController _enemyController)
    {
        
        for(int i = 0; i< _hpBarRTs.Length; i++)
        {
            if (!_hpBarRTs[i].gameObject.activeSelf)
            {
                _hpBarRTs[i].gameObject.SetActive(true);
                _hpBars[i].Init(_enemyController);
                break;
            }
        }
    }
    void Update()
    {
        
    }
}
