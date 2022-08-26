using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using UnityEngine.UI;
using TMPro;

public class WorldSelectorSceneController : MonoBehaviour
{
    
    static string[] _worldNames= { "Lomnicky_0_Llegada de UV", "Einstein_0_alrededores_torre", "PicDuMidi_0_sala_paneles_a_c", "Gregor_0_exterior", "SST_0_residencia_roque", "EST_exterior EST" };
    [SerializeField] private Image[] _worldImages;
    [SerializeField] private Image[] _worldLockImages;
    [SerializeField] private Button[] _worldButtons;
    [SerializeField] private TextMeshProUGUI[] _worldNamesText;
    public void ResetLomnicky()
    {
        PlayerPrefs.DeleteAll();
        GameProgressController.LomnickyClosedCeiling = false;
        GameProgressController.LomnickyTornadoSkill = false;
        GameProgressController.LomnickyFuse = false;
        GameProgressController.LomnickyMotor = false;
        GameProgressController.LomnickyClosedCeiling = false;
        GameProgressController.LomnickyCountdown = false;
        GameProgressController.LomnickyCountdownTime = 0f;
        GameProgressController.LomnickyPuzzleFlareHunters = false;
        GameProgressController.LomnickyRecopiledDataAdvice = false;
        GameProgressController.ResetPiezaCamara();
        GameProgressController.LomnickyPuzzleLayers = false;
    }
    public void BackHome()
    {
        GameEvents.LoadScene.Invoke("MainMenu");
    }

    public void Start()
    {

        _worldImages[0].color = Color.white;
        _worldLockImages[0].gameObject.SetActive(false);
        _worldButtons[0].interactable = true;
        _worldNamesText[0].text = "Lomnický štít";
        GameProgressController.LomnickySolved = true;
        GameProgressController.EinsteinSolved= true;
        GameProgressController.PicDuMidiSolved = true;
        GameProgressController.GregorFinished= true;
        GameProgressController.SSTSolved= true;

        if (GameProgressController.LomnickySolved)
        {
            _worldImages[1].color = Color.white;
            _worldLockImages[1].gameObject.SetActive(false);
            _worldButtons[1].interactable = true;
            _worldNamesText[1].text = "Einstein Tower";
        }
        if (GameProgressController.EinsteinSolved)
        {
            _worldImages[2].color = Color.white;
            _worldLockImages[2].gameObject.SetActive(false);
            _worldButtons[2].interactable = true;
            _worldNamesText[2].text = "Pic du Midi";

        }
        if (GameProgressController.PicDuMidiSolved)
        {
            _worldImages[3].color = Color.white;
            _worldLockImages[3].gameObject.SetActive(false);
            _worldButtons[3].interactable = true;
            _worldNamesText[3].text = "GREGOR";

        }
        if (GameProgressController.GregorFinished)
        {
            _worldImages[4].color = Color.white;
            _worldLockImages[4].gameObject.SetActive(false);
            _worldButtons[4].interactable = true;
            _worldNamesText[4].text = "SST";

        }
        if (GameProgressController.SSTSolved)
        {
            _worldImages[5].color = Color.white;
            _worldLockImages[5].gameObject.SetActive(false);
            _worldButtons[5].interactable = true;
            _worldNamesText[5].text = "EST";
        }

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
