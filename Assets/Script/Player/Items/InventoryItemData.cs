using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItemData : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public GameObject prefab;

    public abstract void Use();

    public void Remove()
    {
        InventoryManager.instance.Remove(this);
    }
}
