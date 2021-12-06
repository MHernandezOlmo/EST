using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PuzzleGameOverUI : MonoBehaviour
{
    const float SHOW_POPUP_ANIM_DURATION = 1f;

    [Header("Deps")]
    public Button retryBtn;
    public Button exitPuzzleBtn;
    public RectTransform gameOverPopup;
    public Image backgroundOverlay;

    void Start()
    {
        retryBtn.onClick.AddListener(OnRetryBtnPressed);
        exitPuzzleBtn?.onClick.AddListener(OnExitPuzzleBtnPressed);
        ShowPopupAnim();
    }

    void OnExitPuzzleBtnPressed() // Return to game
    {
        // TO DO: come back to previous scene
        GameEvents.LoadScene.Invoke("");
    }

    void OnRetryBtnPressed() // Reset scene
    {
        // TO DO: reset puzzle scene, including intro
        GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
    }

    void ShowPopupAnim()
    {
        gameOverPopup.gameObject.SetActive(true);
        gameOverPopup.localScale = Vector3.zero;
        retryBtn.interactable = false;
        exitPuzzleBtn.interactable = false;

        float initialAlpha = backgroundOverlay.color.a;
        backgroundOverlay.color = backgroundOverlay.color.With(a: 0f);

        Action<float> onProgress = (float progress) =>
        {
            gameOverPopup.localScale = Vector3.one * Easings.ElasticEaseOut(progress);
            backgroundOverlay.color = backgroundOverlay.color.With(a: Mathf.Lerp(0f, initialAlpha, progress));
        };

        Action onComplete = () => 
        {
            retryBtn.interactable = true;
            exitPuzzleBtn.interactable = true;
        };

        this.Tween(SHOW_POPUP_ANIM_DURATION, onProgress, onComplete);
    }

    
}
