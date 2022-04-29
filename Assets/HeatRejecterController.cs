using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeatRejecterController : MonoBehaviour
{
    [SerializeField] private Image _glycolAmountImage;
    private bool _addingWater;
    private bool _addingGlycol;
    private float _glycolAmount;
    [SerializeField] private TextMeshProUGUI _waterAmountText;
    [SerializeField] private TextMeshProUGUI _glycolAmountText;
    private void Start()
    {
        _glycolAmount = PlayerPrefs.GetFloat("GlycolAmount", 0.5f);
    }
    public void Back()
    {
        PlayerPrefs.SetFloat("GlycolAmount",_glycolAmount);
        GameProgressController.SetCurrentStartPoint(2);
        GameEvents.LoadScene.Invoke("SST_3_sala_maquinas");
    }
    public void AddWater(bool adding)
    {
        _addingWater = adding;
    }

    public void AddGlycol(bool adding)
    {
        _addingGlycol = adding;
    }

    private void Update()
    {
        if (_addingWater)
        {
            _glycolAmount -= Time.deltaTime/10f;
            if (_glycolAmount <= 0) _glycolAmount = 0f;
        }
        if (_addingGlycol)
        {
            _glycolAmount += Time.deltaTime / 10f;
            if (_glycolAmount >= 1) _glycolAmount = 1f;
        }
        _glycolAmountImage.fillAmount = _glycolAmount;

        float wtrAmount =(1 - _glycolAmount)*100;
        int glcAmount = 100-(int)wtrAmount;
        PlayerPrefs.SetInt("GlycolAmount", glcAmount);

        _waterAmountText.text ="WATER: "+(int)wtrAmount+"%";
        _glycolAmountText.text ="Glycol: "+(int)glcAmount+"%";
    }

}
