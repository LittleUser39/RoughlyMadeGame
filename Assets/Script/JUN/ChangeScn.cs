using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScn : MonoBehaviour
{
    public void ChangingScn(string strScene)
    {
        SceneManager.LoadScene(strScene);
    }
}
