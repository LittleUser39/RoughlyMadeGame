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
           GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().ShowSelectedMonster(index);
        }
    }
    public void OnClick()
    {
        Debug.Log(bState);
        switch(bState)
        {
            case "ATTACK":
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().AttackMonster(index);
            break;
            case "SKILL":
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().UseSkill(index);
            break;
            case "ITEM":
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().UseItem(index);
            break;
            case "ESCAPE":
            break;
        }
        
    }
}
