using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BattleObjectData : ScriptableObject
{
    
    public GameObject prefab = null;
    
    new public string name = "New Item";
    public int HP = 100;
    public int agility;//턴 돌아오는 속도
    public int damage;//기본 데미지

    // 0 = 불 , 1, 물, 2, 풀
    public int elementalAttribute;

    //public abstract void Use();


}

