using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{
    public Image icon;
    public Button button;

    InventoryItemData itemData;

    public void AddItem(InventoryItemData itemData)
    {
        this.itemData = itemData;

        icon.sprite = itemData.icon;
        icon.enabled = true;
        button.interactable = true;
    }

    public void RemoveItem()
    {
        itemData = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public void UseItem()
    {
        Debug.Log("아이템 사용");
        itemData?.Use();
    }
}
