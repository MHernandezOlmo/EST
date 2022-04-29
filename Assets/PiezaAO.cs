using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaAO : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (FindObjectOfType<SSTExteriors>() != null)
            {
                FindObjectOfType<SSTExteriors>().GetPiece();
            }
            else
            {
                FindObjectOfType<SSTCupula>().GetPiece();
            }
            Destroy(gameObject);
        }
    }

}
