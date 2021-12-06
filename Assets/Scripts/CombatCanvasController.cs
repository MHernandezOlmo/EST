using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject _combatCanvas;
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
    }
}
