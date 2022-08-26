using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissipateHeat : MonoBehaviour
{
    private Image _image;
    
    IEnumerator Start()
    {
        _image = GetComponent<Image>();
        Color startingRed = _image.color;
        Color transparentRed = _image.color;
        transparentRed.a = 0f;
        yield return new WaitForSeconds(0.5f);
        for (float i = 0; i < 5f; i += Time.deltaTime)
        {
            _image.color = Color.Lerp(startingRed, transparentRed, i / 5f);
            yield return null;
        }
        _image.color = transparentRed;

    }

    void Update()
    {
        
    }
}
