using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
   GameManager manager;
      
    [SerializeField]
    private string title;
    public string[] conversation;
    int converIndex = 0;
    private void Start() {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
   public bool ReAction()
   {
       if( converIndex < conversation.Length)
       {
            manager.SetActiveDialog(true);
            manager.SetDialogContent(title,conversation[converIndex]);
            converIndex++;
       
            return true;
       }
       else
       {    
           manager.SetActiveDialog(false);
           converIndex = 0;
           return false;
       }
    } 
    public bool Store()
    {
        if (converIndex < conversation.Length)
        {
            manager.SetActiveDialog(true);
            manager.SetDialogContent(title, conversation[converIndex]);
            manager.SetActiveStore(false);
            converIndex++;
            return true;
        }
        else
        {
            manager.SetActiveDialog(false);
            manager.SetActiveStore(true);
            converIndex = 0;
            return false;
        }
    
   }
}
