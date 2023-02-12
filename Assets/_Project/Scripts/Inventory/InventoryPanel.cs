using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.Instance.itemDragAndDropController.OnInventoryButtonClicked(inventory.itemSlots[id]);
        ShowInventory();
    }
}
