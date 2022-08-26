using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanRochAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(8);
        GameEvents.LoadScene.Invoke("PicDuMidiPuzzleAssociation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
