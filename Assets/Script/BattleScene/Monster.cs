using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public GameObject agilityBar;
    public Image  curAgilBar;

    public MonsterBattleData data;
    public string monsterName;
    public float defaultAgility;
    public float agility;
    public int maxHP;
    public int curHP;
    public int damage;

    public int index;

    public Vector2 battlePos;
    public bool isDead;
    // private void Awake()
    // {
    //     isDead=false;
        
    //     monsterName = data.name;
    //     maxHP = data.HP;
    //     damage = data.damage;

    // }
    private void Update()
    {
        if(curHP<=0)
        {
            isDead=true;
        }

    }
}
