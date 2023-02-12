using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] private ToolbarController toolbarController;

    private int _currentSelectedTool;

    private void Start()
    {
        Init();
        toolbarController.onChange += Highlight;
        Highlight(0);
    }

    public override void OnClick(int id)
    {
        toolbarController.Set(id);
        Highlight(id);
    }

    public void Highlight(int id)
    {
        buttons[_currentSelectedTool].Highlight(false);
        _currentSelectedTool = id;
        buttons[_currentSelectedTool].Highlight(true);
    }
}
