using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmacenGregorSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _pc;
    [SerializeField] DialogueTrigger _call;
    [SerializeField] DialogueTrigger _tested;
    [SerializeField] DialogueTrigger _needPlace;
    [SerializeField] GameObject _heatRejecterCanvas;
    [SerializeField] private GameObject _scenePortal;
    IEnumerator Start()
    {
        if (GameProgressController.GregorHasHeatRejecter && !GameProgressController.GregorTestedHR)
        {
            InstantiatePC();
            _scenePortal.gameObject.SetActive(false);

        }
        else
        {
            if (GameProgressController.GregorHasHeatRejecter)
            {
                if (!GameProgressController.GregorDome)
                {
                    yield return new WaitForSeconds(1f);
                    _tested.triggerDialogueEvent(true);
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    _needPlace.triggerDialogueEvent(true);
                }
            }
        }
    }
    public void LoadCinematic()
    {
        GameEvents.LoadScene.Invoke("Gregor_0_domeCinematic");
    }
    public void LoadLab()
    {
        GameEvents.LoadScene.Invoke("Einstein_6_planta-1_sala_del_espectropolarimetroFromGregor");
    }
    public void InstantiatePC()
    {
        _scenePortal.gameObject.SetActive(false);
        GameObject g = Instantiate(_pc);
        g.GetComponent<PCGregorInteractable>().SetDialog(_call);
    }
    public void InstantiateCanvas()
    {
        Instantiate(_heatRejecterCanvas);
    }
}
