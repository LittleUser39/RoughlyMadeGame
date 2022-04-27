using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowManager : MonoBehaviour
{
    public Animator dialog;

    bool isAction;

    public void Action()
    {
        dialog.SetBool("isShow", isAction);
        isAction = true;
    }

    public bool ReAction()
    {
        return !isAction;
    }
}
