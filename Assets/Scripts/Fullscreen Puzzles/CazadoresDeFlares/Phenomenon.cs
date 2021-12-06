using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Phenomenon : MonoBehaviour, IPointerClickHandler
{
    [System.NonSerialized]
    public VideoClip videoClipWhenWasClicked;


    [System.NonSerialized]    
    public bool free = true;

    private void Start() 
    {
        setEnableStatus(false);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("clicked " + gameObject.name);
        videoClipWhenWasClicked = GetComponent<VideoPlayer>().clip;
        FindObjectOfType<CazadoresDeFlaresController>().CurrentClickedPhenomenon = this;
        Select();
    }

    public void Select()
    {
        GetComponent<VideoPlayer>().Pause();
    }


    public void Unselect()
    {
        GetComponent<VideoPlayer>().Play();
    }

    public void Destroy()
    {
        CancelInvoke();
        setEnableStatus(false);
        transform.GetComponent<VideoPlayer>().clip = null;
        free = true;
    }

    public void Activate(VideoClip clip)
    {
        transform.GetComponent<VideoPlayer>().clip = clip;
        setEnableStatus(true);

        Invoke("Fail", (float)clip.length * FindObjectOfType<CazadoresDeFlaresController>().timesToRepeatVideoBeforeFail);

        free = false;
    }

    void setEnableStatus(bool enabled)
    {
        transform.GetComponent<MeshRenderer>().enabled = enabled;
        transform.GetComponent<MeshCollider>().enabled = enabled;
    }

    void Fail()
    {
        Destroy();
        FindObjectOfType<CazadoresDeFlaresController>().subtractLife();
    }
        
}
