using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EligeElFenomeno : PuzzleBehaviour
{
    [Header("Gameplay Settings")]
    [Range(3f, 10f)]
    public float timePerPhoto = 5f;
    public Sprite[] photos;
    public int[] correctAnswers;

    [Space(10)]
    [Header("Style Settings")]
    public Color correctAnswerColor = Color.green;
    public Color wrongAnswersColor = Color.red;
    public Sprite checkMarkSprite;
    public Sprite crossSprite;

    [Space(10)]
    [Header("Scene References")]
    public Button btn_0;
    public Button btn_1;
    public Button btn_2;
    public Button btn_3;
    public RectTransform photo;
    public Image photoImg;
    public Slider countdownBar;
    public Image feedbackImg;
    public Image[] hearts;

    const float INITIAL_WAIT_TIME = 1f;

    const float PHOTO_OFFSCREEN_SPAWN_POS = 1000f;
    const float PHOTO_ON_CORRECT_OFFSCREEN_UPWARDS_POS = 250f;
    const float PHOTO_WRONG_FADE_OUT_SCALE = 0.5f;
    
    const float FEEDBACK_IMG_UP_DISPLACEMENT = 50f;
    const float FEEDBACK_IMG_WRONG_FADE_OUT_SCALE = 1.5f;

    const float SHOW_CARD_ANIM_DURATION = 1f;
    const float FEEDBACK_ANIM_DURATION = 1f;

    const int BTN_1 = 1;
    const int BTN_2 = 2;
    const int BTN_3 = 3;
    const int BTN_4 = 4;
    const int NONE = 0;

    Vector3 photoInitialPos;
    Vector3 feedbackImgInitialPos;

    int currentAnswer = NONE;
    int currentPhoto = 0;

    Color btn1InitialColor, btn2InitialColor, btn3InitialColor, btn4InitialColor;

    int lifes = 3;

    void Start()
    {
        photoInitialPos = photo.position;
        feedbackImgInitialPos = feedbackImg.rectTransform.position;

        countdownBar.maxValue = timePerPhoto;
        countdownBar.value = countdownBar.maxValue;
        
        btn1InitialColor = btn_0.colors.disabledColor;
        btn2InitialColor = btn_1.colors.disabledColor;
        btn3InitialColor = btn_2.colors.disabledColor;
        btn4InitialColor = btn_3.colors.disabledColor;

        btn_0.onClick.AddListener( () =>
        {
            currentAnswer = BTN_1;
        });

        btn_1.onClick.AddListener( () =>
        {
            currentAnswer = BTN_2;
        });

        btn_2.onClick.AddListener( () =>
        {
            currentAnswer = BTN_3;
        });

        btn_3.onClick.AddListener( () =>
        {
            currentAnswer = BTN_4;
        });

        btn_0.interactable = false;
        btn_1.interactable = false;
        btn_2.interactable = false;
        btn_3.interactable = false;
        photo.position = photoInitialPos + PHOTO_OFFSCREEN_SPAWN_POS.Left();
        feedbackImg.enabled = false;

        StartCoroutine(MainLoop());
    }

    IEnumerator MainLoop()
    {
        yield return new WaitForSeconds(INITIAL_WAIT_TIME);

        while(currentPhoto < photos.Length && lifes > 0)
        {
            yield return ShowCard();
            yield return WaitForAnswer();
            
            ShowAnswers();
            if (currentAnswer == correctAnswers[currentPhoto])
            {
                yield return PositiveFeedback();
            }
            else
            {
                RestLife();
                yield return NegativeFeedback();
            }
            HideAnswers();

            currentPhoto++;
        }

        if (lifes <= 0)
        {
            ShowGameOver();
        }
        else
        {
            ShowWin();
        }
    }

    IEnumerator ShowCard()
    {
        photoImg.sprite = photos[currentPhoto];

        Vector3 from = photoInitialPos + PHOTO_OFFSCREEN_SPAWN_POS.Left();
        Vector3 to = photoInitialPos;
        yield return this.TweenCoroutine(SHOW_CARD_ANIM_DURATION, (float t) =>
        {
            photo.position = Vector3.Lerp(from, to, t);
        });
    }

    IEnumerator WaitForAnswer()
    {
        btn_0.interactable = true;
        btn_1.interactable = true;
        btn_2.interactable = true;
        btn_3.interactable = true;
        currentAnswer = NONE;

        for (float timeRemaining = timePerPhoto; timeRemaining > 0; timeRemaining -= exitUI.isShowingExitPopup ? 0 : Time.deltaTime)
        {
            if (currentAnswer != NONE)
            {
                break;
            }

            countdownBar.value = timeRemaining;
            yield return null;
        }

        countdownBar.value = 0f;

        btn_0.interactable = false;
        btn_1.interactable = false;
        btn_2.interactable = false;
        btn_3.interactable = false;
    }

    IEnumerator PositiveFeedback()
    {   
        feedbackImg.enabled = true;
        feedbackImg.sprite = checkMarkSprite;

        Vector3 fromPhoto = photoInitialPos;
        Vector3 toPhoto = photoInitialPos + PHOTO_ON_CORRECT_OFFSCREEN_UPWARDS_POS.Up();
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            photo.position = Vector3.Lerp(fromPhoto, toPhoto, t);
        });

        Vector3 fromFeedback = feedbackImgInitialPos;
        Vector3 toFeedback = feedbackImgInitialPos + FEEDBACK_IMG_UP_DISPLACEMENT.Up();
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            feedbackImg.rectTransform.position = Vector3.Lerp(fromFeedback, toFeedback, t);
        });

        Color fromFeedbackColor = feedbackImg.color.With(a: 1f);
        Color toFeedbackColor = feedbackImg.color.With(a: 0f);
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            feedbackImg.color = Color.Lerp(fromFeedbackColor, toFeedbackColor, t);
        });

        yield return new WaitForSeconds(FEEDBACK_ANIM_DURATION);

        feedbackImg.enabled = false;
        feedbackImg.rectTransform.position = feedbackImgInitialPos;
    }

    IEnumerator NegativeFeedback()
    {   
        feedbackImg.enabled = true;
        feedbackImg.sprite = crossSprite;

        Vector3 from, to, initialScale;
        from = initialScale = photo.localScale;
        to = photo.localScale * PHOTO_WRONG_FADE_OUT_SCALE;
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            photo.localScale = Vector3.Lerp(from, to, t);
        });

        Vector3 fromFeedbackImg, toFeedbackImg, feedbackImgInitialScale;
        fromFeedbackImg = feedbackImgInitialScale = feedbackImg.rectTransform.localScale;
        toFeedbackImg = feedbackImg.rectTransform.localScale * FEEDBACK_IMG_WRONG_FADE_OUT_SCALE;
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            feedbackImg.rectTransform.localScale = Vector3.Lerp(fromFeedbackImg, toFeedbackImg, t);
        });

        float fromAlpha = photo.GetComponent<CanvasGroup>().alpha;
        float toAlpha = 0f;
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            photo.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(fromAlpha, toAlpha, t);
        });

        Color fromFeedbackColor = feedbackImg.color.With(a: 1f);
        Color toFeedbackColor = feedbackImg.color.With(a: 0f);
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            feedbackImg.color = Color.Lerp(fromFeedbackColor, toFeedbackColor, t);
        });

        yield return new WaitForSeconds(FEEDBACK_ANIM_DURATION);

        photo.GetComponent<CanvasGroup>().alpha = 1f;
        photo.localScale = initialScale;
        feedbackImg.rectTransform.localScale = feedbackImgInitialScale;
        feedbackImg.enabled = false;
    }

    void RestLife()
    {
        lifes--;
        
        Vector3 from = hearts[lifes].rectTransform.localScale;
        Vector3 to = Vector3.zero;
        this.Tween(FEEDBACK_ANIM_DURATION, (float t) =>
        {
            hearts[lifes].rectTransform.localScale = Vector3.Lerp(from, to, t);
        });
    }

    void ShowAnswers()
    {
        ColorBlock wrongColors = btn_0.colors;
        wrongColors.disabledColor = wrongAnswersColor;

        ColorBlock correctColor = wrongColors;
        correctColor.disabledColor = correctAnswerColor;

        btn_0.colors = wrongColors;
        btn_1.colors = wrongColors;
        btn_2.colors = wrongColors;
        btn_3.colors = wrongColors;

        if (correctAnswers[currentPhoto] == BTN_1) btn_0.colors = correctColor;
        if (correctAnswers[currentPhoto] == BTN_2) btn_1.colors = correctColor;
        if (correctAnswers[currentPhoto] == BTN_3) btn_2.colors = correctColor;
        if (correctAnswers[currentPhoto] == BTN_4) btn_3.colors = correctColor;
    }

    void HideAnswers()
    {
        ColorBlock prevColors = btn_0.colors;
        prevColors.disabledColor = btn1InitialColor;

        prevColors = btn_1.colors;
        prevColors.disabledColor = btn2InitialColor;

        prevColors = btn_2.colors;
        prevColors.disabledColor = btn3InitialColor;

        prevColors = btn_3.colors;
        prevColors.disabledColor = btn4InitialColor;
    }

    void OnValidate()
    {
        if (Application.isPlaying && photos.Length != correctAnswers.Length)
        {
            Debug.LogError("Elige El Fenomeno: el número de imágenes debe coincidir con el número de respuestas", this);
            Debug.Break();
        }

        for(int i = 0; i < correctAnswers.Length; i++)
        {
            correctAnswers[i] = Mathf.Clamp(correctAnswers[i], 0, 3);
        }

        if (Application.isPlaying && lifes != hearts.Length)
        {
            Debug.LogError("Elige El Fenomeno: debes asignar 3 corazones al array de corazones", this);
            Debug.Break();
        }
    }
}
