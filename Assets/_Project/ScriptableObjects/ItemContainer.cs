using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName = "Data/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> itemSlots;

    public void AddItem(Item item, int count = 1)
    {
        if (item.stackable)
        {
            ItemSlot itemSlot = itemSlots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = itemSlots.Find(x => x.item == null);
                
                if (itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            ItemSlot itemSlot = itemSlots.Find(x => x.item == null);
            
            if (itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }
}
