using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] private ToolbarController _toolbarController;

    private int currentSelectedTool;

    private void Start()
    {
        Init();
        _toolbarController.onChange += Highlight;
        Highlight(0);
    }

    public override void OnClick(int id)
    {
        _toolbarController.Set(id);
        Highlight(id);
    }

    public void Highlight(int id)
    {
        _buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        _buttons[currentSelectedTool].Highlight(true);
    }
}
