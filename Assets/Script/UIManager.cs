using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
   public GameObject dialog;
    public void SetActiveDialog(bool active)
    {
        dialog.SetActive(active);
    }
    public bool GetActiveDialog()
    {
        return dialog.activeSelf; 
    }
}
