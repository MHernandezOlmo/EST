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
    public IEnumerator Advice()
    {
        yield return new WaitForSeconds(0.5f);
        GameEvents.ShowScreenText.Invoke("Obtained spectropolarimeter");
    }

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
                if (GameProgressController.EinsteinUsedPrism)
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
        if (!GameProgressController.EinsteinNoPrismDialog)
        {
            _prismAdvice.gameObject.SetActive(true);
        }
        else
        {
            _prismAdvice.gameObject.SetActive(false);
        }
        if(GameProgressController.EinsteinHasPrism && !GameProgressController.EinsteinUsedPrism)
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

        if (GameProgressController.EinsteinUsedPrism)
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
        GameProgressController.EinsteinNoPrismDialog = true;
        GameProgressController.EinsteinNeedPrism = true;
        //GameEvents.ShowScreenText.Invoke("Contact UV to get a beam-splitter");
        GameEvents.MissionText.Invoke("Make a videocall to UV ");
    }
    public void AnimateSpectropolarimetro()
    {
        StartCoroutine(WaitForSave());
        IEnumerator WaitForSave()
        {
            yield return new WaitForSeconds(2f);
            _animator.SetTrigger("Save");
            _ray2.SetActive(false);
            _rayoBifurcadoL.SetActive(false);
            _rayoBifurcadoR.SetActive(false);
            _ray1.GetComponent<LineRenderer>().SetPosition(1, new Vector3(-0.2892f, 1.41478f, -14.16f));

            StartCoroutine(Advice());
        }
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
        GameProgressController.EinsteinUsedPrism = true;
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
