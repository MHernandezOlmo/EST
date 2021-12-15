using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsController : MonoBehaviour
{
    [SerializeField] ToggleController _OSTToggle;
    [SerializeField] ToggleController _SFXToggle;
    public void EnableMusic()
    {
        GameEvents.ToggleOST.Invoke(true);
    }
    public void DisableMusic()
    {
        GameEvents.ToggleOST.Invoke(false);
    }
    public void EnableSFX()
    {
        GameEvents.ToggleSFX.Invoke(true);
    }

    public void DisableSFX()
    {
        GameEvents.ToggleSFX.Invoke(false);
    }

    private void Start()
    {
        _SFXToggle.SetState(SavedDataController.IsSFXEnabled());
        _OSTToggle.SetState(SavedDataController.IsOSTEnabled());
    }
}
