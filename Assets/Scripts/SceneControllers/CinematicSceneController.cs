using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
public class CinematicSceneController : MonoBehaviour
{
    int _cinematicToPlay;
    string _nextScene;
    [SerializeField]
    TextMeshProUGUI _cinematicTitle = default;
    [SerializeField]
    TextMeshProUGUI _cinematicDescription = default;
    [SerializeField] VideoPlayer _videoPlayer;
    bool canLoad;
    bool isLoading;
    [SerializeField] GameObject _skipButton;
    private void Awake()
    {

        _videoPlayer.loopPointReached += EndReached;
        _skipButton.SetActive(false);
        StartCoroutine(LoadNextScene());
    }

    void EndReached(VideoPlayer vp)
    {
        if (!isLoading)
        {
            LoadWorld();
        }
    }
    public void Skip()
    {
        if (!isLoading)
        {
            AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
            LoadWorld();
        }
    }

    public void LoadWorld()
    {
        //DESMUTEAR
        AudioEvents.unmuteMusic.Invoke();
        AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.Menu);
        GameEvents.LoadScene.Invoke("WorldSelector");
        isLoading = true;
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(5);
        _skipButton.SetActive(true);
        Image skipImage = _skipButton.GetComponent<Image>();
        TextMeshProUGUI skipText = _skipButton.GetComponentInChildren<TextMeshProUGUI>();
        Color transparentWhite = Color.white;
        Color transparentBlack = Color.black;
        transparentBlack.a = 0f;
        transparentWhite.a = 0f;
        for(float i=0; i< 1f; i += Time.deltaTime)
        {
            skipImage.color = Color.Lerp(transparentWhite, Color.white, i);
            skipText.color = Color.Lerp(transparentWhite, Color.white, i);
            yield return null;
        }
        skipImage.color = Color.white;
        skipText.color = Color.white;
        canLoad = true;
    }
}
