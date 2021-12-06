using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Slot : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        FindObjectOfType<CazadoresDeFlaresController>().TouchSlotCallback(this);
    }

    public void Success()
    {
        GetComponent<Animator>().SetTrigger("Success");
    }

    public void Fail()
    {
        GetComponent<Animator>().SetTrigger("Fail");
    }
}
