using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    ScrollRect _scrollRect;
    [SerializeField] List<RectTransform> _elements;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(_elements[0].position);
        for(int i = 0; i< _elements.Count; i++)
        {
            if(_elements[i].position.y < -1050f)
            {
                _elements[i].transform.SetAsFirstSibling();
            }
        }
    }


    void Reposition()
    {
        print("Reposiciono");
    }

}
