using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Encounter : MonoBehaviour
{
    BattleObjectData enemyData;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            enemyData =other.gameObject.GetComponent<MonsterEncounter>().enemyObjectData ;
            
            BattleManager.instance.SetBattleUnits(enemyData, gameObject.GetComponent<Player>());
        }
    }
}
