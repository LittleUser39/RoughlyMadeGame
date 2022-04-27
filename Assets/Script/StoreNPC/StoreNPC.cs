using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNPC : MonoBehaviour, IStoreAction
{
    public Conversation conversation;

    public bool Store()
    {
        return conversation.Store();
    }
}
