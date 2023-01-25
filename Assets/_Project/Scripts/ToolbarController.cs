using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    public Action<int> onChange;
    
    [SerializeField] private int _toolbarSize = 11;

    private int selectedTool;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool += 1;
                selectedTool = selectedTool >= _toolbarSize ? 0 : selectedTool;
            }
            else
            {
                selectedTool -= 1;
                selectedTool = selectedTool < 0 ? _toolbarSize-1 : selectedTool;
            }
            onChange?.Invoke(selectedTool);
        }
    }

    public void Set(int id)
    {
        selectedTool = id;
    }
}
