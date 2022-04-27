using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public enum QuestType
{
    COLLECT,
    KILL,
    ESCORT,
    DELIVERY,
}
public class Quest : MonoBehaviour
{
    public UnityAction<Quest> OnStart;
    public UnityAction<Quest> OnComplate;
   public bool isActive;    //퀘스트가 가능한 상황
   public bool isStarted = false; //퀘스트가 수락됨
   public bool isFinished = false; //퀘스트 완료
   
   bool isCheak;

   public QuestType type;

    public string title;
    
    [TextArea]
    public string description;

    public string requirement;

    public int curAmount;
    public int requireAmount;

    public int expReward;
    public int goldReward;

    public Conversation accept,prograss,complate;
    private void Start() {
        OnStart += QuestManager.instance.QuestStart;
        OnComplate += QuestManager.instance.QuestComplate;
    }
    public void Accept()
    {
        OnStart?.Invoke(this);
        isStarted = true;
        Debug.Log(title + "가 수락됨.");
    }

    public void Prograss()
    {
        curAmount++;
        Debug.Log(title + " 가 진행됨. - " + curAmount + "/" + requirement);
    }

    public void Complate()
    {
        OnComplate?.Invoke(this);
        isActive = false;
        Debug.Log(title + "가 완료됨");
    }
    public void SetActive()
    {
        isActive = true;
    }
    public bool ReAction()
    {
        if(!isStarted) //수락 전
        {
            bool reaction = accept.ReAction();
            if(reaction)
            {
                return true;
            }
            else
            {
                Accept();
                return false;
            }
        }
        else if(!isFinished) // 진행중
        {
         if(curAmount < requireAmount)
            return prograss.ReAction();
            else
            {
                isFinished = true;
                return ReAction();
            }
        }
        else    //완료 시
        {
            bool reaction = complate.ReAction();
              if(reaction)
            {
                return true;
            }
            else
            {
                Complate();
                return false;
            }
        }
    }
}
