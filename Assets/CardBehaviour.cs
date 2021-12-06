using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] RectTransform _backSide, _frontSide;
    RectTransform _myRectTransform;
    [SerializeField] Image _content; 
    bool _turning;
    bool _hidden;
    public void Turn(bool showContent)
    {
        if (!_hidden)
        {
            if (!_turning)
            {
                _turning = true;
                StartCoroutine(CrTurn(showContent));
            }
        }
    }
    public void SetImage(Sprite newContent)
    {
        _content.sprite = newContent;
    }
    public void Hide()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
    IEnumerator CrTurn(bool showContent)
    {
        float turnTime = 0.2f;
        for(float i = 0; i< turnTime; i += Time.deltaTime)
        {
            _myRectTransform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0, 1, 1), i / turnTime);
            yield return null;
        }
        _myRectTransform.localScale = new Vector3(0, 1, 1);
        if (showContent)
        {
            _backSide.gameObject.SetActive(false);
            _frontSide.gameObject.SetActive(true);
        }
        else
        {
            _backSide.gameObject.SetActive(true);
            _frontSide.gameObject.SetActive(false);
        }
        for (float i = 0; i < turnTime; i += Time.deltaTime)
        {
            _myRectTransform.localScale = Vector3.Lerp(new Vector3(0, 1, 1), Vector3.one,  i / turnTime);
            yield return null;
        }
        _myRectTransform.localScale = Vector3.one;
        _turning = false;
    }
    void Start()
    {
        _myRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {

    }
}
