using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Use Item", menuName = "Inventory/UseItem")]
public class UseItemData : InventoryItemData
{
    public override void Use()
    {
        Debug.Log(name + "사용하여 용도에 맞게 작용하고 없어집니다.");
        Debug.Log("플레이어 체력 회복");
        Remove();
    }
}
