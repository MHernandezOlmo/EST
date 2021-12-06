using UnityEngine;
using UnityEngine.Video;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;

public class CazadoresDeFlaresController : MonoBehaviour
{
    public Timer timer;
    public GameObject fade;  
    public GameObject IntroCanvas;

    public float durationInSeconds = 100;
    public int timesToRepeatVideoBeforeFail = 2;
    public int newPhenomenonEachSeconds = 3;
    public SolarPhenomenon[] solarPhenomenons;
    [System.Serializable]
    public class SolarPhenomenon
    {
        public VideoClip video;
        public Slot slot;
        public bool onlyInsideOfSun;
    }

    public Life[] lifes;
    public Phenomenon[] phenomenonsToFillInsideOfSun;

    public UnityEvent onSuccess;
    public UnityEvent onFail;
    public UnityEvent onGamerOver;  
    public UnityEvent onWin;  
    

    [System.NonSerialized]
    public Phenomenon currentClickedPhenomenon = null;
    public Phenomenon CurrentClickedPhenomenon
    {
        set 
        {
            Time.timeScale = 0;
            currentClickedPhenomenon = value; 
            displaySlots(true);
        }
    }

    int lifesCount;

    Component[] phenomenonsToFill;

    bool gameOver = false;

    void Start()
    {
        phenomenonsToFill = GetComponentsInChildren(typeof(Phenomenon));
        if (solarPhenomenons.Length == 0){
            Debug.LogError("CazadoresDeFlaresController no está configurado.");
            return;
        }

        IntroCanvas.SetActive(true);
    }

    public void StartGame()
    {
        timer.remainingTime = durationInSeconds;
        lifesCount = lifes.Length;
        displaySlots(false);
        timer.Play();
        InvokeRepeating("GenerateRandomSolarPhenomenon", 4, newPhenomenonEachSeconds);
    }

    void Update()
    {
    }

    public void Fail(Slot touchedSlot)
    {
        Debug.Log("Restar vida");
        touchedSlot.Fail();
        currentClickedPhenomenon.Destroy();

        subtractLife();
        onFail?.Invoke();
    }

    public void Success(Slot touchedSlot)
    {
        Debug.Log("Correcto");
        onSuccess?.Invoke();

        touchedSlot.Success();
        currentClickedPhenomenon.Destroy();
    }

    public void Win()
    {
        Debug.Log("Win");
        onWin?.Invoke();
        currentClickedPhenomenon = null;
        Time.timeScale = 0;
        Fade(true);
    }

    public void GamerOver()
    {
        Debug.Log("GamerOver");
        onGamerOver?.Invoke();
        currentClickedPhenomenon = null;
        Time.timeScale = 0;
        Fade(true);
        gameOver = true;
    }

    public void TouchSlotCallback(Slot touchedSlot)
    {
        if (!currentClickedPhenomenon ) return;

        if (getSlotFromVideoClip(currentClickedPhenomenon.videoClipWhenWasClicked) != touchedSlot){
            Fail(touchedSlot);
        } else {
            Success(touchedSlot);
        }

        if (currentClickedPhenomenon != null)
            currentClickedPhenomenon.Unselect();
        if (!gameOver) {
            Time.timeScale = 1;
            displaySlots(false);
        }

        currentClickedPhenomenon = null;
    }

    public void subtractLife()
    {
        if (lifesCount > 0)
        {
            lifes[lifes.Length - lifesCount].Destroy();
            lifesCount--;
        } else
            GamerOver();
    }

    void GenerateRandomSolarPhenomenon()
    {
        SetPhenomenonInRandomPosition(GetRandomSolarPhenomenon());
    }

    void SetPhenomenonInRandomPosition(SolarPhenomenon phenomenon)
    {
        Component[] phenomenonsToFill;
        if (phenomenon.onlyInsideOfSun)
            phenomenonsToFill = this.phenomenonsToFillInsideOfSun;
        else 
            phenomenonsToFill = this.phenomenonsToFill;
            
        GetRandomPhenomenonToFillFree(phenomenonsToFill)?.Activate(phenomenon.video);
    }

    SolarPhenomenon GetRandomSolarPhenomenon()
    {
        return solarPhenomenons[Random.Range(0, solarPhenomenons.Length-1)];
    }
    Phenomenon GetRandomPhenomenonToFillFree(Component[] phenomenonsToFill)
    {
        Phenomenon phenomenonToFill = GetRandomPhenomenonToFill(phenomenonsToFill);
        int tries = 0;
        while(!phenomenonToFill.free && tries < 3){
            phenomenonToFill = GetRandomPhenomenonToFill(phenomenonsToFill);
            tries++;
        }

        if (!phenomenonToFill.free) phenomenonToFill = null;

        return phenomenonToFill;
    }

    Phenomenon GetRandomPhenomenonToFill(Component[] phenomenonsToFill)
    {
        return (Phenomenon)phenomenonsToFill[Random.Range(0, phenomenonsToFill.Length-1)];
    }

    Slot getSlotFromVideoClip(VideoClip videoClip)
    {
        return solarPhenomenons.Where(solarPhenomenon => solarPhenomenon.video == videoClip).ToList()[0].slot;
    }

    private void Fade(bool enable)
    {
        fade.GetComponent<Image>().enabled = enable;
    }

    private void displaySlots(bool display)
    {
        foreach(Slot slot in Resources.FindObjectsOfTypeAll(typeof(Slot)))
        {
            slot.gameObject.SetActive(display);
            slot.gameObject.GetComponent<Image>().enabled = display;
            slot.gameObject.GetComponent<Slot>().enabled = display;
        }
    }
}
