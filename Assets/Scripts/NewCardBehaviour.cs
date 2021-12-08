using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCardBehaviour : MonoBehaviour
{

    private int _ID;
    private Roulette _roulette;
    [SerializeField] private SpriteRenderer _frame;
    [SerializeField] private SpriteRenderer _content;
    public int _rotationID;
    public void SetContent(Sprite sp)
    {
        _content.sprite = sp;
    }

    public void ColoContent(Color color)
    {
        _content.color = color;
    }
    public void ColorFrame(Color color)
    {
        if (!_roulette.GetCardValue(_ID))
        {
            _frame.color = color;    
        }
    }
    public void SetID(int id, Roulette ncb)
    {
        _ID = id;
        _rotationID = _ID;
        _roulette = ncb;
    }

    private void OnMouseDown()
    {
        _roulette.RotateIntoID(_ID, _rotationID);
    }

    void Update()
    {
        
        transform.LookAt( transform.position +Vector3.back, Vector3.up);
        transform.localScale =Vector3.one +( Vector3.one* 0.5f * (transform.position.z * -1));
        if (transform.localScale.x < 0)
        {
            transform.localScale = Vector3.zero;
        }
    }
}
