using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject[] playerAgilityBars;
    public GameObject[] enemyAgilityBars;
    public Transform[] enemySpawnSpot;
    public Transform[] playerSpawnSpot;

    public GameObject mousePointer;
    Player originalPlayer;//필드플레이어 원본
    
    public Image playerTurnUI;
    public Image monsterStatusUI;
    public Image playerStatusUI;
    Button[] btns;//맨왼쪽 플레이어선택 버튼 배열
    Button[] btns2;//몬스터 상태 이미지 안의 버튼 배열
    bool isBattleStarted=false;
    public bool isBattlePaused=false;
    

    //List<BattleObjectData> playerUnits;

    List<Player> playerOnField;
    //List<BattleObjectData> enemyUnits;
    List<Monster>enemyOnField;
    //List<GameObject> battleTurn;
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
       // playerUnits = new List<BattleObjectData>();
       // enemyUnits = new List<BattleObjectData>();
      //  battleTurn = new List<GameObject>();
        playerOnField = new List<Player>();
        enemyOnField = new List<Monster>();
    }
    public void PlayerStatusUpdate()
    {
        playerStatusUI.GetComponentInChildren<Text>().text = playerOnField[0].playerName + "  "+ playerOnField[0].curHP+" / "+playerOnField[0].maxHP;
    }
    public void SetBattleUnits(BattleObjectData enemy, Player player)
    {
        Button[] monsterButtons = monsterStatusUI.transform.GetComponentsInChildren<Button>();
        for(int i=0 ; i<Random.Range(1,4); ++i)
        {
            GameObject enemyObj = Instantiate(enemy.prefab,enemySpawnSpot[i].position,Quaternion.identity);
            Monster monster = enemyObj.GetComponent<Monster>();

            ////몬스터 셋업////
            monster.defaultAgility = Random.Range(enemy.minAgility,enemy.maxAgility);//적군 2~5까지 랜덤어질리티
            monster.agility = monster.defaultAgility;
            monster.index = i;
            monster.battlePos = enemySpawnSpot[i].position;
            monster.maxHP = enemy.HP;
            monster.damage = enemy.damage;
            monster.monsterName = enemy.name + (i+1); 
            monster.agilityBar = enemyAgilityBars[i];
            monster.curAgilBar  = monster.agilityBar.transform.GetChild(0).GetComponent<Image>();
            Text txt = monsterButtons[i].transform.GetComponentInChildren<Text>();
            txt.text = monster.monsterName;

            ////몬스터 리스트에 추가 ////
            enemyOnField.Add(monster);
        }
        for(int i=0; i<monsterButtons.Length;++i)
        {
            Text txt = monsterButtons[i].transform.GetComponentInChildren<Text>();
            if(txt.text == "nullPtr")
            {
                //txt.gameObject.SetActive(false);
                monsterButtons[i].gameObject.SetActive(false);
            }
        }
        originalPlayer = player;
        GameObject playerObj = Instantiate(player.gameObject,playerSpawnSpot[0].position,Quaternion.identity);
        playerObj.transform.GetChild(0).gameObject.SetActive(false);
        playerObj.GetComponent<CircleCollider2D>().isTrigger=true;
        Player pObj = playerObj.GetComponent<Player>();
        pObj.agilityBar = playerAgilityBars[0];
        pObj.curAgilBar  = pObj.agilityBar.transform.GetChild(0).GetComponent<Image>();
        
        playerOnField.Add(pObj);
        PlayerStatusUpdate();
        BattleStart();        
    }

    private void BattleStart()
    {
        isBattleStarted = true;
    }

    private void Update()
    {
        if(isBattleStarted && !isBattlePaused)
        {
            GameObject obj = AgilityCount();
            if(null!=obj)
            {
                TakeTurn(obj);
            }
        }
        ///테스트용코드
        if(playerOnField.Count>0)
        {
            if(playerOnField[0].curHP<=0)
            {
                BattleEnd();
            }
        }

    }
    private GameObject AgilityCount()
    {
        for(int i=0; i<enemyOnField.Count;++i)
        {
            enemyOnField[i].agility -=Time.deltaTime;
            enemyOnField[i].curAgilBar.fillAmount = (float)enemyOnField[i].agility / (float)enemyOnField[i].defaultAgility;
            
            

            if(enemyOnField[i].agility<=0)
            {
                enemyOnField[i].agility  = enemyOnField[i].defaultAgility;
                
                return enemyOnField[i].gameObject;
            }
        }
        for(int i=0; i<playerOnField.Count;++i)
        {
            playerOnField[i].agility -=Time.deltaTime;
            playerOnField[i].curAgilBar.fillAmount = (float)playerOnField[i].agility / (float)playerOnField[i].defaultAgility;
           if(playerOnField[i].agility<=0)
            {
                playerOnField[i].agility  = playerOnField[i].defaultAgility;
                
                return playerOnField[i].gameObject;
            }
        }
        
        return null;
    }

    public void TakeTurn(GameObject battleObject)
    {
        isBattlePaused=true;  //순서대기 agilityCounter중지
        if(battleObject.tag == "Player")
        {
            PlayerTurn(battleObject);
        }
        else
        {
            EnemyTurn(battleObject);
        }
    }

    private void PlayerTurn(GameObject battleObject)
    {
        playerTurnUI.gameObject.SetActive(true);
        btns =playerTurnUI.GetComponentsInChildren<Button>();
        for(int i=0;i<btns.Length;++i)
        {
            btns[i].interactable=true;
        }
       
    }
    private void EnemyTurn(GameObject battleObject)
    {
        Monster monster = battleObject.GetComponent<Monster>();
        Vector2 dir = (playerSpawnSpot[0].position-(Vector3)monster.battlePos).normalized;
        EnemyMoveBattle eMove = battleObject.GetComponent<EnemyMoveBattle>();
        eMove.Approach(dir);
        eMove.isTurn=true;

        ///////테스트용코드
        playerOnField[0].curHP -=30;
    }


    public void BattleEnd()
    {
        //플레이어팀 전멸 시 
        //재시작 혹은 게임오버

        //도망 시

        //플레이어 팀 승리 시
        //플레이어 데이터를 이동플레이어 데이터로 옮기고 배틀은 지우고
        //배틀매니저 초기화하고
        //카메라매니저로 카메라 전환시키고
        //필드 초기화 -> 랜덤 다시 함수 여기서 호출
        
        Debug.Log(playerOnField[0].curHP);
        Debug.Log("배틀종료");
        originalPlayer.curHP = playerOnField[0].curHP;
        //originalPlayer.SetUp(playerOnField[0]);
        Debug.Log("오리지날" + originalPlayer.curHP);

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
            btns2[i].GetComponent<DetectMouseOverObject>().bState = "ATTACK";
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
                    pMove = playerOnField[0].GetComponent<PlayerMoveBattle>();
                    pMove.Approach(dir);
                    pMove.isTurn=true;
            break;
            case 2:dir = (enemySpawnSpot[2].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[0].GetComponent<PlayerMoveBattle>();
                    pMove.Approach(dir);
                    pMove.isTurn=true;
            break;
        }
    }
    public void ShowSelectedMonster(int index)
    {
        mousePointer.SetActive(true);
        Vector3 offset = new Vector3(0.5f,0.5f);
        switch(index)
        {
            case 0:mousePointer.transform.position = enemySpawnSpot[0].position + offset;
            break;
            case 1:mousePointer.transform.position = enemySpawnSpot[1].position + offset;
            break;
            case 2:mousePointer.transform.position = enemySpawnSpot[2].position + offset;
            break;
        }
    }
    public void SelectSkill()
    {
        //스킬구현
        PlayerTurnUIOFF();
        btns2 = monsterStatusUI.GetComponentsInChildren<Button>();
        for(int i=0;i<btns2.Length;++i)
        {
            btns2[i].interactable=true;
            btns2[i].GetComponent<DetectMouseOverObject>().bState = "SKILL";
            Debug.Log("SKILL");
        }
    }
    public void UseSkill(int index)
    {
        Vector2 dir;
        PlayerMoveBattle pMove;
        switch(index)
        {
            case 0:dir = (enemySpawnSpot[0].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[0].GetComponent<PlayerMoveBattle>();
                    pMove.UseSkill(dir);
            break;
            case 1:dir = (enemySpawnSpot[1].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[0].GetComponent<PlayerMoveBattle>();
                    pMove.UseSkill(dir);
            break;
            case 2:dir = (enemySpawnSpot[2].position - playerSpawnSpot[0].position).normalized;
                    pMove = playerOnField[0].GetComponent<PlayerMoveBattle>();
                    pMove.UseSkill(dir);
            break;
        }
    }
    public void SelectItem()
    {
        //아이템과 연동
        PlayerTurnUIOFF();
    }
    public void UseItem(int index)
    {

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
