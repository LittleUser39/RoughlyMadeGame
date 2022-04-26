using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Transform pfChracterBattle;
    //[SerializeField] private Transform pfEnemyBattle;

    public Transform[] enemySpawnSpot;
    public Transform[] playerSpawnSpot;

    public GameObject mousePointer;
    
    public Image playerTurnUI;
    public Image monsterStatusUI;
    Button[] btns;//맨왼쪽 플레이어선택 버튼 배열
    Button[] btns2;//몬스터 상태 이미지 안의 버튼 배열
    bool isBattleStarted=false;
    public bool isBattlePaused=false;
    

    List<BattleObjectData> playerUnits;

    List<GameObject> playerOnField;
    //PlayerBattleData playerData;
    List<BattleObjectData> enemyUnits;
    List<GameObject>enemyOnField;
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
        playerUnits = new List<BattleObjectData>();
        enemyUnits = new List<BattleObjectData>();
        battleTurn = new List<GameObject>();
        playerOnField = new List<GameObject>();
        enemyOnField = new List<GameObject>();
    }

    private void Update()
    {
        if(isBattleStarted && !isBattlePaused)
        {
            BattleObjectData objData = AgilityCount();
            if(null!=objData)
            {
                TakeTurn(objData);
            }
        }

    }

    public void SetBattleUnits(BattleObjectData enemy, BattleObjectData player)
    {
        for(int i=0 ; i<Random.Range(1,4); ++i)
        {
            enemy.agility  = Random.Range(2f,5f);//적군 2~5까지 랜덤어질리티
            enemyUnits.Add(enemy);
        }
        playerUnits.Add(player);
        
        PlaceUnits();
        BattleStart();
        
    }
    private void PlaceUnits()
    {
        for(int i =0; i<playerUnits.Count;++i)
        {
            Vector2 pos = playerUnits[i].prefab.transform.position = playerSpawnSpot[i].position;
            GameObject player = Instantiate(playerUnits[i].prefab,pos,Quaternion.identity);
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.GetComponent<CircleCollider2D>().isTrigger=true;
            playerOnField.Add(player);

        }
        for(int i =0; i<enemyUnits.Count;++i)
        {
            Vector2 pos = enemyUnits[i].prefab.transform.position = enemySpawnSpot[i].position;
            GameObject enemy = Instantiate(enemyUnits[i].prefab,pos,Quaternion.identity);
            enemyOnField.Add(enemy);
        }
          
    }
    private void BattleStart()
    {
        isBattleStarted = true;
        //StartCoroutine(InBattle());
    }
    private BattleObjectData AgilityCount()
    {
        for(int i=0; i<enemyUnits.Count;++i)
        {
            enemyUnits[i].agility -=Time.deltaTime;
            if(enemyUnits[i].agility<=0)
            {
                enemyUnits[i].agility  = enemyUnits[i].DefaultAgility;
                return enemyUnits[i];
            }
        }
        for(int i=0; i<playerUnits.Count;++i)
        {
            playerUnits[i].agility -=Time.deltaTime;
            if(playerUnits[i].agility<=0)
            {
                playerUnits[i].agility  = playerUnits[i].DefaultAgility;
                return playerUnits[i];
            }
        }
        
        return null;
    }

    public void TakeTurn(BattleObjectData battleObjectData)
    {
        isBattlePaused=true;  //순서대기 agilityCounter중지
        if(battleObjectData.name == "Player")
        {
           // playerData = (PlayerBattleData)battleObjectData;
            PlayerTurn(battleObjectData);
        }
        else
        {
            EnemyTurn();
        }
    }

    private void PlayerTurn(BattleObjectData battleObjectData)
    {
        playerTurnUI.gameObject.SetActive(true);
        btns =playerTurnUI.GetComponentsInChildren<Button>();
        for(int i=0;i<btns.Length;++i)
        {
            btns[i].interactable=true;
        }
       
    }
    private void EnemyTurn()
    {
        Vector2 dir = (playerSpawnSpot[0].position-enemySpawnSpot[0].position).normalized;
        EnemyMoveBattle eMove = enemyOnField[0].GetComponent<EnemyMoveBattle>();
        eMove.Approach(dir);
        eMove.isTurn=true;
    }


    public void BattleEnd()
    {
        isBattleStarted=false;
    }

    private void PlayerTurnUIOFF()
    {
        for(int i=0;i<btns.Length;++i)
        {
            btns[i].interactable=false;
        }
        playerTurnUI.gameObject.SetActive(false);
    }
    public void SelectBattle()
    {
        //버튼으로 이어서 ui끄고 다음ui로 이동하도록
        PlayerTurnUIOFF();
        btns2 = monsterStatusUI.GetComponentsInChildren<Button>();
        for(int i=0;i<btns2.Length;++i)
        {
            btns2[i].interactable=true;
            //btns2[i].
        }
    }
    public void AttackMonster(int index)
    {
        Vector2 dir;
        PlayerMoveBattle pMove;
        switch(index)
        {
            case 0:dir = (enemySpawnSpot[0].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[0].GetComponent<PlayerMoveBattle>();
                    pMove.Approach(dir);
                    pMove.isTurn=true;
            break;
            case 1:dir = (enemySpawnSpot[1].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[1].GetComponent<PlayerMoveBattle>();
                    pMove.Approach(dir);
                    pMove.isTurn=true;
            break;
            case 2:dir = (enemySpawnSpot[2].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[2].GetComponent<PlayerMoveBattle>();
                    pMove.Approach(dir);
                    pMove.isTurn=true;
            break;
        }
    }
    public void ShowSelectedMonster(int index)
    {
        mousePointer.SetActive(true);
        switch(index)
        {
            case 0:mousePointer.transform.position = enemySpawnSpot[0].position;
            break;
            case 1:mousePointer.transform.position = enemySpawnSpot[1].position;
            break;
            case 2:mousePointer.transform.position = enemySpawnSpot[2].position;
            break;
        }
    }
    public void SelectItem()
    {
        //아이템과 연동
        PlayerTurnUIOFF();
    }
    public void SelectSkill()
    {
        //스킬구현
        PlayerTurnUIOFF();
    }
    public void RunAway()
    {
        //확률로 도망 가능하도록
        PlayerTurnUIOFF();
    }
    IEnumerator InBattle()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
        }
        
    }
    
}
