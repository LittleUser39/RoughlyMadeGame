using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNPC : MonoBehaviour, IStoreAction, IInterAction
{
    public Conversation conversation;

    public bool ReAction()
    {
        return conversation.Store(); 
    }
    public bool Store()
    {
        return conversation.Store();
    }
}
