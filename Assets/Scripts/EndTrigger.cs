using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] int piece;
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("PieceToSecure",piece);
        GameEvents.LoadScene.Invoke("SecurePiece");
    }
}
