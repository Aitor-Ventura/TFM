using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] private ItemSlot _itemSlot;
    [SerializeField] private GameObject _dragItemIcon;
    
    private RectTransform _dragItemIconRectTransform;
    
    private void Start()
    {
        _itemSlot = new ItemSlot();
        _dragItemIconRectTransform = _dragItemIcon.GetComponent<RectTransform>();
        _dragItemIcon.SetActive(false);
    }

    private void Update()
    {
        if (_dragItemIcon.activeInHierarchy)
        {
            _dragItemIconRectTransform.position = Input.mousePosition;
        }
    }


    public void OnInventoryButtonClicked(ItemSlot inventoryItemSlot)
    {
        if (_itemSlot.item == null)
        {
            _itemSlot.Copy(inventoryItemSlot);
            inventoryItemSlot.Clear();
        }
        else
        {
            Item item = inventoryItemSlot.item;
            int count = inventoryItemSlot.count;
            
            inventoryItemSlot.Copy(_itemSlot);
            _itemSlot.Set(item, count);
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (_itemSlot.item == null)
        {
            _dragItemIcon.SetActive(false);
        }
        else
        {
            _dragItemIcon.SetActive(true);
            _dragItemIcon.GetComponent<Image>().sprite = _itemSlot.item.icon;
        }
    }
}
