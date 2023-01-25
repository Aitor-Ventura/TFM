using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer _inventory;
    public List<InventoryButton> _buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SetIndex();
        ShowInventory();
    }

    private void OnEnable()
    {
        ShowInventory();
    }

    private void SetIndex()
    {
        for (int i = 0; i < _inventory.itemSlots.Count && i < _buttons.Count; i++)
        {
            _buttons[i].SetIndex(i);
        }
    }

    public void ShowInventory()
    {
        for (int i = 0; i < _inventory.itemSlots.Count && i < _buttons.Count; i++)
        {
            if (_inventory.itemSlots[i].item == null)
            {
                _buttons[i].Clean();
            }
            else
            {
                _buttons[i].Set(_inventory.itemSlots[i]);
            }
        }       
    }
    
    public virtual void OnClick(int id)
    {
        Debug.Log("Clicked " + id);
    }
}
