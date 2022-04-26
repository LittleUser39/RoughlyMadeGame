using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectMouseOverObject : MonoBehaviour
{
    public int index;
    public void CheckInterActable()
    {
        if(GetComponent<Button>().interactable)
        {
           BattleManager.instance.ShowSelectedMonster(index);
        }
    }
    public void OnClickAttack()
    {
        BattleManager.instance.AttackMonster(index);
    }
}
