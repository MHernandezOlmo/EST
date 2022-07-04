using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaPanelesRotosSceneController : MonoBehaviour
{
    //[SerializeField]
    //GameObject _chispas;
    //[SerializeField] GameObject _panelRoto;
    //[SerializeField]
    //DialogueTrigger _dialogTrigger;
    //void Awake()
    //{
    //    if (GameProgressController.IsPanelFixed())
    //    {
    //        _panelRoto.SetActive(false);
    //    }
    //}
    //IEnumerator Start()
    //{
    //    if (GameProgressController.IsPanelFixed())
    //    {

    //        yield return new WaitForSeconds(0.25f);

    //        if (!GameProgressController.GetRecopiledDataAdvicePDMD())
    //        {
    //            _dialogTrigger.triggerDialogueEvent(true);
    //            yield return new WaitForSeconds(0.2f);
    //            while (CurrentSceneManager._state != GameStates.Exploration)
    //            {
    //                yield return null;
    //            }
    //            GameEvents.ShowScreenText.Invoke("Find the filters");
    //            GameProgressController.SetArrivedToPicDuMidi(true);
    //        }
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    [SerializeField] private DialogueTrigger _filtersDialog;
    private IEnumerator Start()
    {

        if (GameProgressController.PicDuMidiPuzzleCoronagraph)
        {
            if (!GameProgressController.PicDuMidiFindFiltersAdvice)
            {
                GameProgressController.PicDuMidiFindFiltersAdvice = true;
                yield return new WaitForSeconds(1f);
                _filtersDialog.triggerDialogueEvent(true);
            }
        }
    }
    public void FindFilters()
    {
        GameEvents.ShowScreenText.Invoke("Find the filters");
    }

    public void LoadCoronagraph()
    {
        GameProgressController.PicDuMidiNeedContactUV = false;
        GameEvents.LoadScene.Invoke("PicDuMidiPuzzleCoronagraph");
    }
}
