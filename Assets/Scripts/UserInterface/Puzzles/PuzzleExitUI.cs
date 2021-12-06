using System;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleExitUI : MonoBehaviour
{
    const float SHOW_POPUP_ANIM_DURATION = 1f;
    const float HIDE_POPUP_ANIM_DURATION = 0.2f;

    [HideInInspector]
    public bool isShowingExitPopup = false;

    [Header("Deps")]
    public Button exitBtn;
    public Button confirmBtn;
    public Button backBtn;
    public RectTransform confirmationPopup;
    public Image backgroundOverlay;

    Color backgroundOverlayInitialColor;

    void Start()
    {
        confirmationPopup.localScale = Vector3.zero;
        backgroundOverlay.gameObject.SetActive(false);
        backgroundOverlayInitialColor = backgroundOverlay.color;

        exitBtn.onClick.AddListener(OnExitPressed);
        confirmBtn.onClick.AddListener(OnExitConfirmed);
        backBtn.onClick.AddListener(OnExitCancelled);
    }

    public void Close()
    {
        OnExitCancelled();
    }

    void OnExitConfirmed() // Return to game
    {
        // TO DO: come back to previous scene
        Debug.Log("TO DO: RETURN TO PREVIOUS SCENE");
    }

    void OnExitCancelled() // Hide popup
    {
        confirmationPopup.gameObject.SetActive(true);
        confirmationPopup.localScale = Vector3.one;
        confirmBtn.interactable = false;
        backBtn.interactable = false;
        
        Color from = backgroundOverlayInitialColor;
        Color to = backgroundOverlayInitialColor.With(a: 0f);

        Action<float> onProgress = (float progress) =>
        {
            confirmationPopup.localScale = Vector3.one * (1 - progress);
            backgroundOverlay.color = Color.Lerp(from, to, progress);
        };

        Action onComplete = () => 
        {
            confirmBtn.interactable = true;
            backBtn.interactable = true;
            exitBtn.interactable = true;
            confirmationPopup.gameObject.SetActive(false);

            isShowingExitPopup = false;
            backgroundOverlay.gameObject.SetActive(false);
        };

        this.Tween(HIDE_POPUP_ANIM_DURATION, onProgress, onComplete);
    }

    void OnExitPressed() // Show popup
    {
        confirmationPopup.gameObject.SetActive(true);
        confirmationPopup.localScale = Vector3.zero;
        confirmBtn.interactable = false;
        backBtn.interactable = false;
        backgroundOverlay.gameObject.SetActive(true);

        // TODO: pause the rest of the puzzle here

        exitBtn.interactable = false;

        isShowingExitPopup = true;

        Color from = backgroundOverlayInitialColor.With(a: 0f);
        Color to = backgroundOverlayInitialColor;
        Action<float> onProgress = (float progress) =>
        {
            confirmationPopup.localScale = Vector3.one * Easings.ElasticEaseOut(progress);
            backgroundOverlay.color = Color.Lerp(from, to, progress);
        };

        Action onComplete = () =>
        {
            confirmBtn.interactable = true;
            backBtn.interactable = true;
        };

        this.Tween(SHOW_POPUP_ANIM_DURATION, onProgress, onComplete);
    }

    
}
