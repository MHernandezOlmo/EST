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
    IEnumerator Start()
    {
        if(GameProgressController.GregorHasHeatRejecter && !GameProgressController.GregorTestedHR)
        {
            InstantiatePC();
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
        GameEvents.LoadScene.Invoke("Einstein_3_planta_1_sala_archivoFromGregor");
    }
    public void InstantiatePC()
    {
        GameObject g = Instantiate(_pc);
        g.GetComponent<PCGregorInteractable>().SetDialog(_call);
    }
    public void InstantiateCanvas()
    {
        Instantiate(_heatRejecterCanvas);
    }
    void Update()
    {
        
    }
}
