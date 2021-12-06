using UnityEngine.Events;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class Timer : MonoBehaviour
{

    public float remainingTime = 100; 
    public UnityEvent tick;

    public bool playOnAwake = true;


    bool timerIsRunning;
    TextMeshProUGUI timeInUI;

    private void Start() {
        timeInUI = GetComponent<TextMeshProUGUI>();
        UpdateTimeInUI();
        if (playOnAwake) Play();
    }
    
    public void Play(){
        timerIsRunning = true;
    }

    private void Update() {
        if (timerIsRunning)
        {
            if(remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimeInUI();
            } 
            else
            {
                timerIsRunning = false;
                Tick();
            }
        }
    }

    private void Tick(){
        tick?.Invoke();
    }

    public void UpdateTimeInUI(){
        timeInUI.SetText(Mathf.Round(remainingTime).ToString());
    }

}
