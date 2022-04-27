using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAgilBar : MonoBehaviour
{
    public GameObject pfAgilBar;
    GameObject AgilCanvas;
    RectTransform agilBar;
    public float height =  0.7f;

    Image curAgilBar;

    float curAgil;
    float DefaultAgil;

    //GameObject parentObj;

    private void Start()
    {
        AgilCanvas = GameObject.FindGameObjectWithTag("Respawn");
        agilBar=Instantiate(pfAgilBar,AgilCanvas.transform).GetComponent<RectTransform>();
        curAgilBar = agilBar.transform.GetChild(0).GetComponent<Image>();
    }
    private void Update()
    {
        Vector3 _hpBarPos = 
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,transform.position.y+height,0));
        agilBar.position = _hpBarPos;
        curAgilBar.fillAmount = (float)curAgil / (float)DefaultAgil;
    }

    public void GetCurHP(int _curHP, int _maxHP)
    {
        curAgil = _curHP;
        DefaultAgil = _maxHP;
        // if(curAgil<=0)
        // {
        //     Destroy(pfAgilBar);
        // }
    }

}
