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
