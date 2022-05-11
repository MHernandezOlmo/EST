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
        if(_hpBars.Length == 0)
        {
            Debug.LogWarning("Cuidaico que lo mismo no hay barras en el array");
        }
        _combatCanvas.SetActive(false);
        foreach(GameObject g in _hpBars)
        {
            g.SetActive(false);
        }
    }
}
