using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemContainer _inventory;
    [SerializeField] private List<InventoryButton> _buttons;

    private void Start()
    {
        SetIndex();
        ShowInventory();
    }

    private void SetIndex()
    {
        for (int i = 0; i < _inventory.itemSlots.Count; i++)
        {
            _buttons[i].SetIndex(i);
        }
    }

    private void ShowInventory()
    {
        for (int i = 0; i < _inventory.itemSlots.Count; i++)
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
}
