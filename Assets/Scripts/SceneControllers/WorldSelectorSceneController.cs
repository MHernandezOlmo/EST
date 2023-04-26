﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class WorldSelectorSceneController : MonoBehaviour
{
    static string[] _worldNames= { "Lomnicky_0_Llegada de UV", "Einstein_0_alrededores_torre", "PicDuMidi_0_sala_paneles_a_c", "Gregor_0_exterior", "SST_0_residencia_roque", "EST_exterior EST" };
    [SerializeField] private bool _allUnlockedForTest;
    [SerializeField] private Image[] _worldImages;
    [SerializeField] private Image[] _worldLockImages;
    [SerializeField] private Button[] _worldButtons;
    [SerializeField] private TextMeshProUGUI[] _worldNamesText;
    [SerializeField] private Color _lockedColor;
    const string _gameProgressFileName = "GameProgressData.json";

    public void Reset()
    {
        bool lomnickySolved = GameProgressController.LomnickySolved;
        bool einsteinSolved = GameProgressController.EinsteinSolved;
        bool picdumidisolved = GameProgressController.PicDuMidiSolved;
        bool gregorSolved = GameProgressController.GregorFinished;
        bool sstSolved = GameProgressController.SSTSolved;
        bool estSolved = GameProgressController.ESTFinished;
        PlayerPrefs.DeleteAll();
        File.Delete(Application.persistentDataPath + "/" + _gameProgressFileName);
        GameProgressController.LomnickySolved = lomnickySolved;
        GameProgressController.EinsteinSolved= einsteinSolved;
        GameProgressController.PicDuMidiSolved= picdumidisolved;
        GameProgressController.GregorFinished= gregorSolved;
        GameProgressController.SSTSolved= sstSolved;
        GameProgressController.ESTFinished= estSolved;

    }
    public void BackHome()
    {
        GameEvents.LoadScene.Invoke("MainMenu");
    }

    public void Start()
    {
        foreach(Image i in _worldImages)
        {
            i.color = _lockedColor;
        }
        _worldImages[0].color = Color.white;
        _worldLockImages[0].gameObject.SetActive(false);
        _worldButtons[0].interactable = true;
        _worldNamesText[0].text = "Lomnický štít";
        _worldNamesText[1].text = "Einstein Tower";
        _worldNamesText[2].text = "Pic du Midi";
        _worldNamesText[3].text = "GREGOR";
        _worldNamesText[4].text = "SST";
        _worldNamesText[5].text = "EST";
        if (_allUnlockedForTest)
        {
            GameProgressController.LomnickySolved = true;
            GameProgressController.EinsteinSolved = true;
            GameProgressController.PicDuMidiSolved = true;
            GameProgressController.GregorFinished = true;
            GameProgressController.SSTSolved = true;
        }

        if (GameProgressController.LomnickySolved)
        {
            _worldImages[1].color = Color.white;
            _worldLockImages[1].gameObject.SetActive(false);
            _worldButtons[1].interactable = true;
        }
        if (GameProgressController.EinsteinSolved)
        {
            _worldImages[2].color = Color.white;
            _worldLockImages[2].gameObject.SetActive(false);
            _worldButtons[2].interactable = true;
        }
        if (GameProgressController.PicDuMidiSolved)
        {
            _worldImages[3].color = Color.white;
            _worldLockImages[3].gameObject.SetActive(false);
            _worldButtons[3].interactable = true;
        }
        if (GameProgressController.GregorFinished)
        {
            _worldImages[4].color = Color.white;
            _worldLockImages[4].gameObject.SetActive(false);
            _worldButtons[4].interactable = true;
        }
        if (GameProgressController.SSTSolved)
        {
            _worldImages[5].color = Color.white;
            _worldLockImages[5].gameObject.SetActive(false);
            _worldButtons[5].interactable = true;
        }
    }

    public void LoadWorld(int world)
    {
        Reset();
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
                PlayerPrefs.SetFloat("GlycolAmount", 0.5f);
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
}
