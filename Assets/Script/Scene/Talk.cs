using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    public Text talkName; // 실제 채팅이 나오는 텍스트
    public Text talkDescription; // 캐릭터 이름이 나오는 텍스트

    private string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextShow());
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            isButtonClicked = true;
    }


    IEnumerator Effects(string name, string description)
    {
        talkName.text = name;
        writerText = "";

        //텍스트 타이핑 효과
        for (int temp = 0; temp < description.Length; temp++)
        {
            writerText += description[temp];
            talkDescription.text = writerText;
            yield return null;
        }

        //키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextShow()
    {
        yield return StartCoroutine(Effects("너", "....."));
        yield return StartCoroutine(Effects("너", "나의 미래를 위해 코딩을 준비하는 중인데"));
        yield return StartCoroutine(Effects("너", "아니 싯팔 되는 게 하나도 없어!"));
        yield return StartCoroutine(Effects("너", "뭐라도 얻어보기 위해.. 머리를 좀 식히기 위해"));
        yield return StartCoroutine(Effects("너", "지금부터 이세계로 떠나는 거야!!"));
    }
}
