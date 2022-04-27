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
        curAgilBar.fillAmount = (float)curAgil / (float)DefaultAgil;
    }

    public void GetCurAgil(int _curAgil, int _default)
    {
        curAgil = _curAgil;
        DefaultAgil = _default;
        // if(curAgil<=0)
        // {
        //     Destroy(pfAgilBar);
        // }
    }

}
