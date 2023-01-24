using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _icon;
    [SerializeField] private TextMeshProUGUI _count;

    private int index;

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void Set(ItemSlot slot)
    {
        _icon.sprite = slot.item.icon;
        
        if (slot.item.stackable)
        {
            _count.text = slot.count.ToString();
        }
        else
        {
            _count.text = "";
        }
    }

    public void Clean()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);

        _count.gameObject.SetActive(false);
    }
}
