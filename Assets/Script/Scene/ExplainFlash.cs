using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainFlash : MonoBehaviour
{
    public Text flashText;

    private void Start()
    {
        flashText = GetComponent<Text>();
        StartCoroutine("ShowReady");
    }

    IEnumerator ShowReady()
    {
        int temp = 0;
        while (temp < 5)
        {
            yield return new WaitForSeconds(0.5f);
            flashText.text = "Press SpaceBar to continue !";
            yield return new WaitForSeconds(0.5f);
            flashText.text = "";
            yield return new WaitForSeconds(0.5f);
            temp++;
        }
    }
}
