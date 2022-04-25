using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public InventoryItemData itemData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (InventoryManager.instance.Add(itemData))
        {
            Debug.Log("먹었다 : " + itemData.name);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("아이템창이 가득 찼다.");
        }
    }
}
