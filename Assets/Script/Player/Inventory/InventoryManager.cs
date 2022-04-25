using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager instance
    {
        get
        {
            return _instance;
        }
    }

    public InventoryUI inventoryUI;

    public List<InventoryItemData> items = new List<InventoryItemData>();
    public int maxSize = 10;

    private void Awake()
    {
        _instance = this;
    }

    public bool Add(InventoryItemData item)
    {
        if (items.Count == maxSize)
            return false;

        items.Add(item);
        inventoryUI.UpdateUI();
        return true;
    }

    public void Remove(InventoryItemData item)
    {
        items.Remove(item);
        inventoryUI.UpdateUI();
    }
}
