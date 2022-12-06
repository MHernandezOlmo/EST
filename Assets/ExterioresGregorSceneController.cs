using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class ExterioresGregorSceneController : MonoBehaviour
{

    [SerializeField] private DialogueTrigger _missionDialog;
    [SerializeField] private DialogueTrigger _ovensAdviceDialog;
    [SerializeField] private DialogueTrigger _ovensAdviceDialog2;
    [SerializeField] private GameObject _timePanel, _bushesCollider;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Transform _retryPos;
    [SerializeField] Image _heatImage;
    [SerializeField] Image _termometerFillImage;
    private float _temperature;
    private PlayerController _player;
    private bool _ovensAdvice, _ovensAdvice2, _sceneChange, _heatStarted;
    int _bushes;
    private Coroutine _crTimeCount;
    private float _currentTimeCount;

    IEnumerator Start()
    {
        _player = FindObjectOfType<PlayerController>();
        yield return null;
        if (GameProgressController.GregorHeatAdvices)
        {
            _camera.Priority = 50;
            Camera.main.transform.position = _camera.transform.position;
            _player.transform.position = _retryPos.position;
        }
        yield return new WaitForSeconds(1f);
        if (GameProgressController.GregorHeatAdvices)
        {
            EnableBushInteractables();
            ShowMissionPanel();
            EnableHeat();
            _bushesCollider.SetActive(true);
        }
        else
        {
            _missionDialog.triggerDialogueEvent(true);
            _termometerFillImage.fillAmount = 0.1f;
            _heatImage.color = Color.Lerp(new Color(1, 0, 0, 0), Color.red, 0.1f);
        }
    }

    public void EnableHeat()
    {
        StartCoroutine(CrEnableHeat());
        IEnumerator CrEnableHeat()
        {
            float dur = 1f;
            _temperature = (70 - Vector3.Distance(_player.transform.position, transform.position)) / 100f;
            for (float i = 0; i < dur; i+= Time.deltaTime)
            {
                _termometerFillImage.fillAmount = (0.4f + (_temperature * 0.6f)) * i/dur;
                _heatImage.color = Color.Lerp(new Color(1, 0, 0, 0), Color.red, Mathf.Clamp(0.1f + (_temperature * i / dur), 0f, _temperature));
                yield return null;
            }
            _termometerFillImage.fillAmount = (0.4f + (_temperature * 0.6f));
            _heatImage.color = Color.Lerp(new Color(1, 0, 0, 0), Color.red, _temperature);
            _heatStarted = true;
        }
    }

    public void AddBush()
    {
        _bushes++;
        string targetTx = "<size=140%>Bushes: " + _bushes + "/6";
        GameEvents.ShowScreenText.Invoke(targetTx);
        if (_bushes == 6)
        {
            GameEvents.ClearMissionText.Invoke();
            StopCoroutine(_crTimeCount);
            PlayerPrefs.SetInt("TimeCounter", 0);
            _timePanel.SetActive(false);
            if (!_sceneChange)
            {
                _sceneChange = true;
                GameEvents.LoadScene.Invoke("Gregor_0_exteriorBis");
            }
        }
    }

    public void StopTimeCount()
    {
        if (_crTimeCount != null)
        {
            StopCoroutine(_crTimeCount);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(_player.transform.position, transform.position);
        if (!GameProgressController.GregorHeatAdvices)
        {
            if (!_ovensAdvice && distance < 20)
            {
                _ovensAdvice = true;
                _ovensAdviceDialog.triggerDialogueEvent(true);
            }
            if (!_ovensAdvice2 && distance < 12)
            {
                _ovensAdvice2 = true;
                _ovensAdviceDialog2.triggerDialogueEvent(true);
            }
        }
        if (_heatStarted)
        {
            _temperature = (70 - Vector3.Distance(_player.transform.position, transform.position)) / 100f;
            if (_temperature < 0.4f)
            {
                _temperature = 0.4f;
            }
            _termometerFillImage.fillAmount = 0.4f + (_temperature * 0.6f);
            _heatImage.color = Color.Lerp(new Color(1, 0, 0, 0), Color.red, _temperature);
        }
    }

    public void EnableBushInteractables()
    {
        foreach(InteractableBush b in FindObjectsOfType<InteractableBush>())
        {
            b.EnableInteractable();
        }
    }

    public void ShowMissionPanel()
    {
        //GameEvents.ShowScreenText.Invoke("Collect the bushes");
        StartBushMission();
        GameProgressController.GregorHeatAdvices = true;
    }

    public void StartBushMission()
    {
        if (GameProgressController.GregorHeatAdvices)
        {
            _currentTimeCount = 100f;
        }
        else
        {
            _currentTimeCount = 75f;
        }
        _timePanel.SetActive(true);
        _crTimeCount = StartCoroutine(CrTimeCount());
        PlayerPrefs.SetInt("TimeCounter", 1);
        IEnumerator CrTimeCount()
        {
            while (_currentTimeCount > 0)
            {
                _currentTimeCount -= Time.deltaTime;
                int minutes = (int)_currentTimeCount / 60;
                int seconds = (int)_currentTimeCount % 60;
                _timeText.text = "<mspace=0.75em>" + minutes.ToString("00") + ":" + seconds.ToString("00");
                yield return null;
            }
            PlayerPrefs.SetInt("TimeCounter", 0);
            GameEvents.LoadScene.Invoke("Gregor_0_exterior");
        }
    }
}
