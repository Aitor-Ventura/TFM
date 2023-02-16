using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;

    private void OnEnable()
    {
        ShowInventory();
    }
    
    private void Start()
    {
        Init();
    }

    private void LateUpdate()
    {
        if (!inventory.isDirty) return;
        
        ShowInventory(); 
        inventory.isDirty = false;
    }

    public void Init()
    {
        SetIndex();
        ShowInventory();
    }

    private void SetIndex()
    {
        for (int i = 0; i < inventory.itemSlots.Count && i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void ShowInventory()
    {
        for (int i = 0; i < inventory.itemSlots.Count && i < buttons.Count; i++)
        {
            if (inventory.itemSlots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.itemSlots[i]);
            }
        }       
    }
    
    public virtual void OnClick(int id)
    {
        Debug.Log("Clicked " + id);
    }
}
