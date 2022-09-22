using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (_sceneName == "Gregor_0_dome")
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
            else if(_sceneName == "Gregor_0_exteriorBis" && !GameProgressController.GregorDome && PlayerPrefs.GetInt("BlockDoor", 0) == 0)
            {
                if(SceneManager.GetActiveScene().name == "Gregor_1_sotano")
                {

                }
                else
                {
                    GameEvents.ShowScreenText.Invoke("First look at the trapdoor!");
                    StartCoroutine(WaitAndInteract());
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
        yield return new WaitForSeconds(2f);
        _interacted = false;
    }
    private void Start()
    {
        base.Start();
        _interactableMarker = transform;
    }
}
