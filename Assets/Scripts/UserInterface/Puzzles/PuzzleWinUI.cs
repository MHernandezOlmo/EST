using System;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleWinUI : MonoBehaviour
{
    const float SHOW_POPUP_ANIM_DURATION = 1f;

    [Header("Deps")]
    public Button continueBtn;
    public RectTransform winPopup;
    public Image backgroundOverlay;

    void Start()
    {
        continueBtn.onClick.AddListener(OnContinueBtnPressed);
        ShowPopupAnim();
    }

    void OnContinueBtnPressed() // Return to game & mark puzzle as beaten
    {
        // TO DO: come back to previous scene
        Debug.Log("TO DO: RETURN TO PREVIOUS SCENE");
    }

    void ShowPopupAnim()
    {
        continueBtn.interactable = false;
        winPopup.localScale = Vector3.zero;

        float initialAlpha = backgroundOverlay.color.a;
        backgroundOverlay.color = backgroundOverlay.color.With(a: 0f);

        Action<float> onProgress = (float progress) =>
        {
            winPopup.localScale = Vector3.one * Easings.ElasticEaseOut(progress);
            backgroundOverlay.color = backgroundOverlay.color.With(a: Mathf.Lerp(0f, initialAlpha, progress));
        };

        Action onComplete = () => 
        {
            continueBtn.interactable = true;
        };

        this.Tween(SHOW_POPUP_ANIM_DURATION, onProgress, onComplete);
    }
}
