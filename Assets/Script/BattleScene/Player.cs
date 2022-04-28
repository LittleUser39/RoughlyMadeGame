using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    public GameObject agilityBar;
    public Image  curAgilBar;
    public PlayerBattleData data;
    public string playerName;
    public float defaultAgility;
    public float agility;
    public int maxHP;
    public int curHP;
    public int damage;
    public Vector2 battlePos;
    public bool isDead;
    private void Awake()
    {
        isDead=false;

        playerName = data.name;
        defaultAgility = data.agility;
        agility = data.agility;
        maxHP = data.HP;
        curHP = data.HP;
        damage = data.damage;

    }
    private void Update()
    {
        if(curHP<=0)
        {
            isDead=true;
        }
    }
    
}
