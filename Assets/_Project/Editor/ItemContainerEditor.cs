using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemContainer container = target as ItemContainer;
        
        if (container == null)
        {
            return;    
        }
        
        if (GUILayout.Button("Clear container"))
        {
            for (int i = 0; i < container.itemSlots.Count; i++)
            {
                container.itemSlots[i].item = null;
                container.itemSlots[i].count = 0;
            }
        }

        DrawDefaultInspector();
    }
}
