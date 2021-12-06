using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuSceneController : MonoBehaviour
{
    [SerializeField]
    RectTransform _initialMenuHolder;
    [SerializeField]
    RectTransform _mainMenuHolder;
    [SerializeField]
    RectTransform _optionsMenuHolder;

    [SerializeField]
    Button _continueGameButton;
    [SerializeField]
    ToggleController _OSTToggle;
    [SerializeField]
    ToggleController _SFXToggle;
    [SerializeField] Sprite _purpleButton;
    bool _changing;
    public void EnableMusic()
    {
        GameEvents.ToggleOST.Invoke(true);
    }
    public void DisableMusic()
    {
        GameEvents.ToggleOST.Invoke(false);
    }
    public void EnableSFX()
    {
        GameEvents.ToggleSFX.Invoke(true);
    }

    public void DisableSFX()
    {
        GameEvents.ToggleSFX.Invoke(false);
    }
    public void HideOptions()
    {
        if (!_changing)
        {
            StartCoroutine(CrHideOptions());
        }
    }
    public void ShowOptions()
    {
        if (!_changing)
        {
            StartCoroutine(CrShowOptions());
        }
    }
    IEnumerator CrShowOptions()
    {
        yield return StartCoroutine(Hide(_mainMenuHolder, 0.5f));
        StartCoroutine(Show(_optionsMenuHolder, 0.5f));
    }
    IEnumerator CrHideOptions()
    {
        yield return StartCoroutine(Hide(_optionsMenuHolder, 0.5f));
        StartCoroutine(Show(_mainMenuHolder, 0.5f));
    }
    public void ShowMenu()
    {
        if (!_changing)
        {
            StartCoroutine(CrShowMenu());
        }
    }

    IEnumerator CrShowMenu()
    {
        yield return StartCoroutine(Hide(_initialMenuHolder, 0.5f));
        StartCoroutine(Show(_mainMenuHolder, 0.5f));
    }
    private void Start()
    {

        _SFXToggle.SetState(SavedDataController.IsSFXEnabled());
        _OSTToggle.SetState(SavedDataController.IsOSTEnabled());


        if (GameProgressController.GetCurrentScene()!="")
        {
            _continueGameButton.interactable = true;
            _continueGameButton.GetComponent<Image>().sprite = _purpleButton;
            _continueGameButton.GetComponent<Image>().overrideSprite = _purpleButton;
        }
        else
        {
            _continueGameButton.interactable = false;
        }
    }


    public void StartNewGame()
    {
        PlayerPrefs.SetInt("CinematicToPlay", 0);
        PlayerPrefs.SetString("SceneAfterCinematic", "Lomnicky_0_Llegada de UV");
        GameProgressController.Reset();
        GameEvents.LoadScene.Invoke("Cinematic");
    }

    public void ContinueGame()
    {
        GameEvents.LoadScene.Invoke(GameProgressController.GetCurrentScene());
    }
    public void ToggleMusic(bool toggleMusic)
    {
        
    }

    public void ToggleAudio(bool toggleAudio)
    {
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public IEnumerator Hide(RectTransform holder, float hideTime)
    {
        _changing = true;
        Image[] imagesToHide = holder.GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textsToHide = holder.GetComponentsInChildren<TextMeshProUGUI>();
        List<Color> imagesColors = new List<Color>();
        List<Color> textsColors = new List<Color>();
        List<Color> imagesColorsTransparent = new List<Color>();
        List<Color> textsColorsTransparent = new List<Color>();
        for (int i = 0; i<imagesToHide.Length; i++)
        {
            imagesColors.Add(imagesToHide[i].color);
            Color c = imagesToHide[i].color;
            c.a = 0;
            imagesColorsTransparent.Add(c);
        }
        for (int i = 0; i < textsToHide.Length; i++)
        {
            textsColors.Add(textsToHide[i].color);
            Color c = textsToHide[i].color;
            c.a = 0;
            textsColorsTransparent.Add(c);
        }

        for (float i = 0; i< hideTime; i+=Time.deltaTime)
        {
            for(int j =0; j< imagesToHide.Length; j++)
            {
                imagesToHide[j].color = Color.Lerp(imagesColors[j], imagesColorsTransparent[j], i/hideTime);
            }
            for (int j = 0; j < textsToHide.Length; j++)
            {
                textsToHide[j].color = Color.Lerp(textsColors[j], textsColorsTransparent[j], i / hideTime);
            }
            yield return null;
        }
        for (int j = 0; j < imagesToHide.Length; j++)
        {
            imagesToHide[j].color =imagesColorsTransparent[j];
        }
        for (int j = 0; j < textsToHide.Length; j++)
        {
            textsToHide[j].color =textsColorsTransparent[j];
        }

        holder.gameObject.SetActive(false);
        for (int i = 0; i < imagesToHide.Length; i++)
        {
            imagesToHide[i].color = imagesColors[i];
        }
        for (int i = 0; i < textsToHide.Length; i++)
        {
            textsToHide[i].color = textsColors[i];
        }
        _changing = false;
    }
    public IEnumerator Show(RectTransform holder, float hideTime)
    {
        _changing = true;
        Image[] imagesToShow = holder.GetComponentsInChildren<Image>(true);
        TextMeshProUGUI[] textsToShow = holder.GetComponentsInChildren<TextMeshProUGUI>(true);
        List<Color> imagesColors = new List<Color>();
        List<Color> textsColors = new List<Color>();
        List<Color> imagesColorsTransparent = new List<Color>();
        List<Color> textsColorsTransparent = new List<Color>();
        for (int i = 0; i < imagesToShow.Length; i++)
        {
            imagesColors.Add(imagesToShow[i].color);
            Color c = imagesToShow[i].color;
            c.a = 0;
            imagesColorsTransparent.Add(c);
        }
        for (int i = 0; i < textsToShow.Length; i++)
        {
            textsColors.Add(textsToShow[i].color);
            Color c = textsToShow[i].color;
            c.a = 0;
            textsColorsTransparent.Add(c);

        }
        for (int i = 0; i < imagesToShow.Length; i++)
        {
            imagesToShow[i].color = imagesColorsTransparent[i];
        }
        for (int i = 0; i < textsToShow.Length; i++)
        {
            textsToShow[i].color = textsColorsTransparent[i];
        }
        holder.gameObject.SetActive(true);

        for (float i = 0; i < hideTime; i += Time.deltaTime)
        {
            for (int j = 0; j < imagesToShow.Length; j++)
            {
                imagesToShow[j].color = Color.Lerp(imagesColorsTransparent[j], imagesColors[j],  i / hideTime);
            }
            for (int j = 0; j < textsToShow.Length; j++)
            {
                textsToShow[j].color = Color.Lerp(textsColorsTransparent[j], textsColors[j],  i / hideTime);
            }
            yield return null;
        }
        for (int i = 0; i < imagesToShow.Length; i++)
        {
            imagesToShow[i].color = imagesColors[i];
        }
        for (int i = 0; i < textsToShow.Length; i++)
        {
            textsToShow[i].color = textsColors[i];
        }
        _changing = false;
    }

}
