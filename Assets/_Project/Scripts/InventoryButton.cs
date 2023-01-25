using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEngine.UI.Image _icon;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private UnityEngine.UI.Image _highlightImage;

    private int index;

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void Set(ItemSlot slot)
    {
        _icon.gameObject.SetActive(true);
        _icon.sprite = slot.item.icon;
        
        if (slot.item.stackable)
        {
            _count.gameObject.SetActive(true);
            _count.text = slot.count.ToString();
        }
        else
        {
            _count.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);

        _count.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(index);
    }
    
    public void Highlight(bool b)
    {
        _highlightImage.gameObject.SetActive(b);
    }
}
