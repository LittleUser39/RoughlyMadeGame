using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour,IInterAction
{
   public Conversation conversation;
  public Quest[] quests;
  //public Quest curQuest = null;
  private void Awake() {
    quests = GetComponentsInChildren<Quest>();
  }
  public bool ReAction()
  {
     // 1. 가능한 퀘 있으면 퀘
     foreach(Quest quest in quests)
     {
       if(quest.isActive)
       {
         return quest.ReAction();
       }
     }
     // 2. 퀘 없으면 대화
     return  conversation.ReAction();
  }
}
