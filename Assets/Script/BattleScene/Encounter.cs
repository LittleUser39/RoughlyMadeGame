using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Encounter : MonoBehaviour
{
    public BattleObjectData battleObjData;
    public CameraManager CManager;
    BattleObjectData enemyData;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("아직안충돌");
        if(other.gameObject.tag == "Monster")
        {
            enemyData =other.gameObject.GetComponent<MonsterEncounter>().enemyObjectData ;
            Debug.Log("충돌");
            BattleManager.instance.SetBattleUnits(enemyData, battleObjData);
            CManager.OnBattle();
        }
    }
}
