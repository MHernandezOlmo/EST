using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCheck : MonoBehaviour
{
    private RectTransform _rectTransform;
    private GridLayoutGroup _layoutGroup;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _layoutGroup = GetComponent<GridLayoutGroup>();
        _layoutGroup.cellSize = new Vector2( Mathf.Abs(_rectTransform.sizeDelta.x / 6f), Mathf.Abs(_rectTransform.sizeDelta.y / 6f));
        _layoutGroup.spacing = new Vector2( Mathf.Abs(_rectTransform.sizeDelta.x / 6f), Mathf.Abs(_rectTransform.sizeDelta.y / 6f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
