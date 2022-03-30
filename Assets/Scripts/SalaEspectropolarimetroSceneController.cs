using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaEspectropolarimetroSceneController : MonoBehaviour
{
    [SerializeField] GameObject _ray1, _ray2;
    [SerializeField] LineRenderer _lineRenderer;
    [SerializeField] GameObject _rayoBifurcadoL;
    [SerializeField] GameObject _rayoBifurcadoR;
    [SerializeField] DialogueTrigger _prismAdvice;
    [SerializeField] GameObject _spectropolarimetroInteractable;
    [SerializeField] GameObject _beamSplitter;
    [SerializeField] GameObject _mesa;
    [SerializeField] Animator _animator;
    [SerializeField] DialogueTrigger _hasEspectroPolarimetro;
    private bool _rayBlocked;
    public bool RayBlocked
    {
        get
        {
            return _rayBlocked;
        }
        set
        {
            _rayBlocked = value;
            if (_rayBlocked)
            {
                _ray2.SetActive(false);
            }
            else
            {
                _ray2.SetActive(true);
                if (GameProgressController.GetUsedPrismEinstein())
                {
                    SaveEspectropolarimetro();
                }
                else
                {
                    _beamSplitter.SetActive(false);
                    _rayoBifurcadoL.SetActive(false);
                    _rayoBifurcadoR.SetActive(false);
                }
            }
        }
    }
    void Start()
    {
        CurrentSceneManager._skillEnabled = false;
        if (!GameProgressController.GetShownPrismDialog())
        {
            _prismAdvice.gameObject.SetActive(true);
        }
        else
        {
            _prismAdvice.gameObject.SetActive(false);
        }
        if(GameProgressController.GetHasPrismEinstein() && !GameProgressController.GetUsedPrismEinstein())
        {
            _spectropolarimetroInteractable.SetActive(true);
        }

        if (GameProgressController.GetIsRayCrossingBasement())
        {
            _ray1.SetActive(true);
            _ray2.SetActive(true);
        }
        else
        {
            _ray1.SetActive(false);
            _ray2.SetActive(false);
            _rayoBifurcadoL.SetActive(false);
            _rayoBifurcadoR.SetActive(false);
        }

        if (GameProgressController.GetUsedPrismEinstein())
        {
            SaveEspectropolarimetro();
        }
        else
        {
            _beamSplitter.SetActive(false);
            _rayoBifurcadoL.SetActive(false);
            _rayoBifurcadoR.SetActive(false);
        }

    }
    public void PrismAdvice()
    {
        GameProgressController.SetShownPrismDialog(true);
        GameProgressController.SetNeedsPrismEinstein(true);
    }
    public void AnimateSpectropolarimetro()
    {
        _ray2.SetActive(false);
        _rayoBifurcadoL.SetActive(false);
        _rayoBifurcadoR.SetActive(false);
        _ray1.GetComponent<LineRenderer>().SetPosition(1, new Vector3(-0.2892f, 1.41478f, -14.16f));
        _animator.SetTrigger("Save");
    }
    public void SaveEspectropolarimetro()
    {
        _ray2.SetActive(false);
        _rayoBifurcadoL.SetActive(false);
        _rayoBifurcadoR.SetActive(false);
        _mesa.SetActive(false);
        _ray1.GetComponent<LineRenderer>().SetPosition(1,new Vector3( -0.2892f,1.41478f,-14.16f));
    }
    public void UseBeamSplitter()
    {
        GameProgressController.SetUsedPrismEinstein(true);
        HasPrism();
        _beamSplitter.SetActive(true);

    }
    public void HasPrism()
    {
        _lineRenderer.SetPosition(3, new Vector3(1.8f, 1.414f, -4.67f));
        _rayoBifurcadoL.SetActive(true);
        _rayoBifurcadoR.SetActive(true);
    }
}
