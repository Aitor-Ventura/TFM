using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string name;
    public Sprite icon;
    public bool stackable;
    public ToolAction onAction;
    public ToolAction onTileMapAction;
    public ToolAction onItemUsedAction;
    public Crop crop;
}
