using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ToolbarController : MonoBehaviour
{
    public Action<int> onChange;
    
    [SerializeField] private int toolbarSize = 11;

    private int _selectedTool;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                _selectedTool += 1;
                _selectedTool = _selectedTool >= toolbarSize ? 0 : _selectedTool;
            }
            else
            {
                _selectedTool -= 1;
                _selectedTool = _selectedTool < 0 ? toolbarSize-1 : _selectedTool;
            }
            onChange?.Invoke(_selectedTool);
        }
    }

    public void Set(int id)
    {
        _selectedTool = id;
    }

    public Item GetItem => GameManager.Instance.inventoryContainer.itemSlots[_selectedTool].item;
}
