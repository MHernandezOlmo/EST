using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablonInteractable : Interactable
{
    [SerializeField]
    Image _tablon;
    public override void Interact()
    {
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UINext);
        GameEvents.ChangeGameState.Invoke(GameStates.Cinematic);
        StartCoroutine(CrShowTablon());   
    }
    public void Hide()
    {
        StartCoroutine(CrHideTablon());
    }
    IEnumerator CrHideTablon()
    {
        Color transparentWhite = new Color(1, 1, 1, 0);
        for (float i = 0; i < 0.25f; i += Time.deltaTime)
        {
            _tablon.color = Color.Lerp(Color.white, transparentWhite, i / 0.25f);
            _tablon.rectTransform.localScale = Vector3.Lerp( Vector3.one, Vector3.zero, i / 0.25f);
            yield return null;
        }
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.UIPanelDisappear);
        _tablon.rectTransform.localScale = Vector3.zero;
        GameEvents.ChangeGameState.Invoke(GameStates.Exploration);
    }
    IEnumerator CrShowTablon()
    {
        Color transparentWhite = new Color(1, 1, 1, 0);
        for(float i =0; i< 0.25f; i += Time.deltaTime)
        {
            _tablon.color = Color.Lerp(transparentWhite, Color.white, i / 0.25f);
            _tablon.rectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.25f);
            yield return null;
        }
        _tablon.rectTransform.localScale = Vector3.one;
        
    }

    void Start()
    {
        base.Start();
    }
}
