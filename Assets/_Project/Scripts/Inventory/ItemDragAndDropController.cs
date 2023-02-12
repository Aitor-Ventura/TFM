using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    [SerializeField] private GameObject dragItemIcon;
    
    private RectTransform _dragItemIconRectTransform;
    
    private void Start()
    {
        itemSlot = new ItemSlot();
        _dragItemIconRectTransform = dragItemIcon.GetComponent<RectTransform>();
        dragItemIcon.SetActive(false);
    }

    private void Update()
    {
        if (dragItemIcon.activeInHierarchy)
        {
            _dragItemIconRectTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (Camera.main == null) return;
                    
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;
                    
                    ItemSpawnManager.Instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);
                    
                    itemSlot.Clear();
                    dragItemIcon.SetActive(false);
                }
            }
        }
    }


    public void OnInventoryButtonClicked(ItemSlot inventoryItemSlot)
    {
        if (itemSlot.item == null)
        {
            itemSlot.Copy(inventoryItemSlot);
            inventoryItemSlot.Clear();
        }
        else
        {
            Item item = inventoryItemSlot.item;
            int count = inventoryItemSlot.count;
            
            inventoryItemSlot.Copy(itemSlot);
            itemSlot.Set(item, count);
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            dragItemIcon.SetActive(false);
        }
        else
        {
            dragItemIcon.SetActive(true);
            dragItemIcon.GetComponent<Image>().sprite = itemSlot.item.icon;
        }
    }
}
