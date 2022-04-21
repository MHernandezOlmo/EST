using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCanvasController : MonoBehaviour
{
    [SerializeField] GameObject _combatCanvas;
    [SerializeField] GameObject[] _hpBars;

    private void Start()
    {
        Hide();
    }
    public void Show()
    {
        _combatCanvas.SetActive(true);
    }

    public void Hide()
    {
        _combatCanvas.SetActive(false);
        foreach(GameObject g in _hpBars)
        {
            g.SetActive(false);
        }
    }
}
