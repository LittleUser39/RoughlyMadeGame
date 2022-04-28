using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
 
    public static GameManager instance
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
    }
    public BattleManager battleMgr;
    public GameObject dialog;
    public Text nameText;
    public Text descriptionText;
    
    public void SetActiveDialog(bool active)
    {
        dialog.SetActive(active);
    }
    public void SetDialogContent(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
    }
    public void ResetBM(GameObject battleManager)
    {
        Destroy(battleManager);
        Instantiate(battleMgr,new Vector3(0,0,0),Quaternion.identity);
    }
}
