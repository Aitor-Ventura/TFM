using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEngine.UI.Image icon;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private UnityEngine.UI.Image highlightImage;

    private int _index;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        
        if (slot.item.stackable)
        {
            count.gameObject.SetActive(true);
            count.text = slot.count.ToString();
        }
        else
        {
            count.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        count.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(_index);
    }
    
    public void Highlight(bool b)
    {
        highlightImage.gameObject.SetActive(b);
    }
}
