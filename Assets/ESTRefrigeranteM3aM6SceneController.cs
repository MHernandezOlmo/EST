using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTRefrigeranteM3aM6SceneController : MonoBehaviour
{
    bool[] _mirrors;
    [SerializeField] private DialogueTrigger _dialogue;

    public void SetMirror(int index)
    {
        _mirrors[index] = true;
        bool allMirrors = true;
        int mirrorCount = 0;
        for (int i = 0; i < _mirrors.Length; i++)
        {
            if (_mirrors[i])
            {
                mirrorCount++;
            }
            if (!_mirrors[i])
            {
                allMirrors = false;
            }
        }
        GameEvents.ShowScreenText.Invoke($"Mirror {index} refilled. {mirrorCount}/4");
        if (allMirrors)
        {
            FindObjectOfType<MissionCanvasController>().HideMission();
            PlayDialog();
        }
    }
    public void PlayDialog()
    {
        _dialogue.triggerDialogueEvent(true);
        GameProgressController.ESTMirrorsM3M6 = true;
    }
    
    void Start()
    {
        _mirrors = new bool[4];
    }
}
