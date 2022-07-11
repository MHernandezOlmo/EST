using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeInteractable : Interactable
{
    [SerializeField] private string _sceneName;
    [SerializeField] private int _startingPoint;
    bool _interacted;
    public override void Interact()
    {
        if (!_interacted)
        {
            _interacted = true;
            GameProgressController.SetCurrentStartPoint(_startingPoint);
            if(_sceneName == "Gregor_0_dome")
            {
                if (FindObjectOfType<CountdownCanvas>() != null)
                {
                    GameEvents.LoadScene.Invoke("Gregor_0_openDome");
                }
                else
                {
                    GameEvents.LoadScene.Invoke(_sceneName);
                }
            }
            else
            {
                GameEvents.LoadScene.Invoke(_sceneName);
            }
        }

    }
    IEnumerator WaitAndInteract()
    {
        
        yield return null;
        yield return new WaitForSeconds(2f);

    }
    private void Start()
    {
        base.Start();
        _interactableMarker = transform;
    }
}
