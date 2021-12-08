using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezasObserver : MonoBehaviour
{
    TMPro.TextMeshProUGUI _text;
    void Start()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
        int piezasObtenidas = 0;
        for (int i = 0; i < 6; i++)
        {
            if (GameProgressController.GetPiezaCamara(i))
            {
                piezasObtenidas++;
            }
        }

        if (piezasObtenidas == 6)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameProgressController.IsChoosePhenomenomSolved())
        {
            _text.text = "";
        }
        else
        {
            int piezasObtenidas = 0;
            for (int i = 0; i < 6; i++)
            {
                if (GameProgressController.GetPiezaCamara(i))
                {
                    piezasObtenidas++;
                }
            }
            _text.text = "Pieces obtained: " + piezasObtenidas + "/6";
        }

    }
}
