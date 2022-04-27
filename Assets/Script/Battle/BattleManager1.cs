using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Transform pfChracterBattle;
    //[SerializeField] private Transform pfEnemyBattle;

    bool isBattleStarted=false;
    List<GameObject> battleTurn;
    private static BattleManager _instance;
 
    public static BattleManager instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {   
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    private void Update()
    {
        //if()
    }

    public bool BattleCount()
    {
        return false;
    }

    public void BattleStart(List<GameObject> battleObjects)
    {
        battleTurn=battleObjects;
        isBattleStarted = true;
        StartCoroutine(InBattle());
    }
    public void BattleEnd()
    {
        isBattleStarted=false;
    }
    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 spawnPos;
        if(isPlayerTeam)
        {
            spawnPos = new Vector3(-3.65f,1.17f);
        }
        else
        {
            spawnPos = new Vector3(4.12f,0.91f);
        }
        Transform characterTransform = Instantiate(pfChracterBattle,spawnPos,Quaternion.identity);
        //CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        //characterBattle.SetUp(isPlayerTeam);
    }

    public void SelectBattle()
    {
        //버튼으로 이어서 ui끄고 다음ui로 이동하도록
    }
    public void SelectItem()
    {
        //아이템과 연동
    }
    public void SelectSkill()
    {
        //스킬구현
    }
    public void RunAway()
    {
        //확률로 도망 가능하도록
    }
    IEnumerator InBattle()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
        }
        
    }
    
}
