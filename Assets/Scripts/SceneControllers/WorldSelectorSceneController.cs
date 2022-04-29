using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using UnityEngine.UI;

public class WorldSelectorSceneController : MonoBehaviour
{
    
    static string[] _worldNames= { "Lomnicky_0_Llegada de UV", "Einstein_0_alrededores_torre", "PicDuMidi_0_sala_paneles_a_c", "Gregor_0_exterior", "SST_0_residencia_roque", "EST" };
    [SerializeField] private Image _einsteinImage;
    [SerializeField] private Image _einsteinImageLock;
    public void BackHome()
    {
        GameEvents.LoadScene.Invoke("MainMenu");
    }

    public void Start()
    {
        // if (!GameProgressController.GetIsLomnickySolved())
        // {
        //     _einsteinImage.color = Color.black;
        //     _einsteinImage.transform.parent.GetComponent<Button>().interactable = false;
        //     _einsteinImageLock.gameObject.SetActive(true);
        // }
    }

    public void LoadWorld(int world)
    {
        GameProgressController.SetCurrentStartPoint(0);
        switch (world)
        {
            case 0:
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.Lomnicky);
                break;
            case 1:
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.TorreEinstein);
                break;
            case 2:
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.Gregor);
                break;
            case 3:
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.PicDuMidi);
                break;
            case 4:
                GameProgressController.Parejas = false;
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.SST);
                break;
            case 5:
                AudioEvents.playMusicTransitionWithMusicCode.Invoke(MusicManager.MusicCode.EST);
                break;
        }
        AudioEvents.playSoundWithName.Invoke(SFXManager.AudioCode.SmoothSelect);
        GameEvents.LoadScene.Invoke(_worldNames[world]);
    }

    public void LoadMenu()
    {
        GameEvents.LoadScene.Invoke("MainMenu");
    }
    
    void Update()
    {
        
    }
}
