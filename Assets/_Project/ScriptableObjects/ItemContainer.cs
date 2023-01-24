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
}
