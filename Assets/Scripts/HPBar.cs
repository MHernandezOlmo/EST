using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Image _mask;
    RectTransform _rectTransform;
    Camera _mainCamera;
    [SerializeField] private bool _isPlayer;
    private PlayerController _pc;

    private bool _showingHP;
    private Coroutine cr;
    public void Init(EnemyController newEnemyController)
    {
        _mainCamera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();
        newEnemyController.SetHPBar(this);
    }

    private void Awake()
    {
        if (_isPlayer)
        {
            SetPlayer(FindObjectOfType<PlayerController>());    
        }
        
    }

    public void SetPlayer(PlayerController pc)
    {
        _pc = pc;
        _rectTransform = GetComponent<RectTransform>();
        _isPlayer = true;
        _mainCamera = Camera.main;
        pc._currentHPBar = this;
        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void Show()
    {
        if ((CurrentSceneManager._state != GameStates.Combat))
        {
            _showingHP = true;
            if (cr!=null)
            {
                StopCoroutine(cr);
            }
            cr = StartCoroutine(CrHideHP());    
        }
    }

    IEnumerator CrHideHP()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        transform.GetChild(0).gameObject.SetActive(false);
        _showingHP = false;
    }
    
    public void UpdateData(float amount, Vector3 worldPosition)
    {
        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        _mask.fillAmount = amount;
        _rectTransform.position = _mainCamera.WorldToScreenPoint(worldPosition);
    }
    private void Update()
    {
        if (_isPlayer)
        {
            if (CurrentSceneManager._state == GameStates.Combat)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                if (!_showingHP)
                {
                    transform.GetChild(0).gameObject.SetActive(false);    
                }
            
            }
            _mask.fillAmount = (float)_pc.GetHP()/(float)_pc.GetMaxHP();
            _rectTransform.position = _mainCamera.WorldToScreenPoint(_pc.transform.position+Vector3.up*2.5f);
        }

    }
    public void Stop()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}