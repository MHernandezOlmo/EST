using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTCupulaSceneController : MonoBehaviour
{
    [SerializeField] public GameObject _b1;
    [SerializeField] public GameObject _b2;
    [SerializeField] public GameObject _b3;

    [SerializeField] private DialogueTrigger _test;
    bool b1, b2, b3;

    [SerializeField] public Material _green;
    [SerializeField] public Material _red;

    IEnumerator Start()
    {
        _b1.GetComponent<MeshRenderer>().material = _red;   
        _b2.GetComponent<MeshRenderer>().material = _red;   
        _b3.GetComponent<MeshRenderer>().material = _red;
        yield return new WaitForSeconds(0.5f);
        _test.triggerDialogueEvent();
    }

    public void PressButton(int index)
    {
        switch (index)
        {
            case 0:
                b1 = true;
                _b1.GetComponent<MeshRenderer>().material = _green;
                break;

            case 1:
                b2 = true;
                _b2.GetComponent<MeshRenderer>().material = _green;
                break;

            case 2:
                b3 = true;
                _b3.GetComponent<MeshRenderer>().material = _green;
                break;
        }
        if(b1 && b2 && b3)
        {
            GameEvents.LoadScene.Invoke("EST_BigRobotDie");
        }
        StartCoroutine(CrRestoreButton(index));
    }

    IEnumerator CrRestoreButton(int index)
    {
        switch (index)
        {
            case 0:
                yield return new WaitForSeconds(1);
                b1 = false;
                _b1.GetComponent<MeshRenderer>().material = _red;
                break;

            case 1:
                yield return new WaitForSeconds(6);
                b2 = false;
                _b2.GetComponent<MeshRenderer>().material = _red;
                break;

            case 2:
                yield return new WaitForSeconds(4);
                b3 = false;
                _b3.GetComponent<MeshRenderer>().material = _red;
                break;
        }
    }

}
