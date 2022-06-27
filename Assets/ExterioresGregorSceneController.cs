using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExterioresGregorSceneController : MonoBehaviour
{

    [SerializeField] private DialogueTrigger _missionDialog;
    [SerializeField] private DialogueTrigger _ovensAdviceDialog;
    [SerializeField] private DialogueTrigger _ovensAdviceDialog2;
    [SerializeField] Image _heatImage;
    [SerializeField] Image _termometerFillImage;
    private float _temperature;
    private PlayerController _player;
    private bool _ovensAdvice, _ovensAdvice2, _sceneChange, _heatStarted;
    int _bushes;
    IEnumerator Start()
    {
        _player = FindObjectOfType<PlayerController>();
        yield return new WaitForSeconds(1f);
        _missionDialog.triggerDialogueEvent(true);
        _termometerFillImage.fillAmount = 0.1f;
        _heatImage.color = Color.Lerp(new Color(1, 0, 0, 0), Color.red, 0.1f);
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
        if(_bushes == 6)
        {
            if (!_sceneChange)
            {
                _sceneChange = true;
                GameEvents.LoadScene.Invoke("Gregor_0_exteriorBis");
            }
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(_player.transform.position, transform.position);
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
}
