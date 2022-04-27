using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BattleObjectData : ScriptableObject
{
    
    public GameObject prefab = null;
    
    new public string name = "New Data";
    public int HP;

    public float minAgility;//몬스터 민첩 랜덤최소값
    public float maxAgility;//몬스터 민첩 랜덤 최대값
    public float agility;//턴 돌아오는 속도
    public float DefaultAgility;//안바뀌는값;
    public int damage;//기본 데미지

    // 0 = 불 , 1, 물, 2, 풀
    public int elementalAttribute;

    //public abstract void Use();


}

