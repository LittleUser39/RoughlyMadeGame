using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
   private static QuestManager _instance;
   public static QuestManager instance
   {
       get
       {
           return _instance;
       }
   }

public GameObject ui;
public Text title;
public Text description;
private Quest curQuest;
   private void Awake() {
       _instance = this;
   }

   private void Update() {
           if(null != curQuest)
           {
            title.text = curQuest.title;
            description.text = curQuest.description;
           }
           else
           {
               title.text = "퀘스트 없음";
               description.text = "  ";
           }
   }
   public void QuestStart(Quest quest)
   {
       //퀘스트 창에 현재 퀘스트 표시
        Debug.Log("퀘스트 시작");
        Debug.Log("퀘스트 이름 : " + quest.title);
        Debug.Log("퀘스트 설명 :" + quest.description);

       curQuest = quest;
       
   }
   public void QuestComplate(Quest quest)
   {
       //보상진행
        Debug.Log("퀘스트 완료");
        Debug.Log("경험치 보상 : " + quest.expReward);
        Debug.Log("골드 보상 :" + quest.goldReward);

       curQuest = null;
   }
   public void OnItemCollect(string itemName)
   {
        if( null == curQuest )
            return;
        if(curQuest.type != QuestType.COLLECT)
            return;
        if(curQuest.requirement != itemName)
            return;

            curQuest.Prograss();
   }
}
