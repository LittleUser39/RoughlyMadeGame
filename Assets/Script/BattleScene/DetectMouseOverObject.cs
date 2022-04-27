using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectMouseOverObject : MonoBehaviour
{
    public int index;

    // public enum buttonState
    // {
    //     ATTACK,
    //     SKILL,
    //     ITEM,
    //     ESCAPE,
    // }
    public string bState;
    public void CheckInterActable()
    {
        if(GetComponent<Button>().interactable)
        {
           BattleManager.instance.ShowSelectedMonster(index);
        }
    }
    public void OnClick()
    {
        Debug.Log(bState);
        switch(bState)
        {
            case "ATTACK":
            BattleManager.instance.AttackMonster(index);
            break;
            case "SKILL":
            BattleManager.instance.UseSkill(index);
            break;
            case "ITEM":
            BattleManager.instance.UseItem(index);
            break;
            case "ESCAPE":
            break;
        }
        
    }
}
