using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolarpediaEntryTitle : MonoBehaviour
{
    private int _entryIndex;
    public int EntryIndex
    {
        get
        {
            return _entryIndex;
        }
        set
        {
            _entryIndex = value;
        }
    }
    private int _subEntryIndex;
    public int SubEntryIndex
    {
        get
        {
            return _subEntryIndex;
        }
        set
        {
            _subEntryIndex = value;
        }
    }
    [SerializeField] private TextMeshProUGUI _title;
    private SolarPediaController _controller;
    public void Init(string title, int entryIndex, int subEntryIndex, SolarPediaController controller)
    {
        _title.text = title;
        _entryIndex = entryIndex;
        _subEntryIndex = subEntryIndex;
        _controller = controller;
        GetComponent<Button>().onClick.AddListener(()=>_controller.ShowFinalContent(entryIndex, subEntryIndex));
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
