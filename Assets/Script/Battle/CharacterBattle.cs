using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private BaseHero baseHero;
    private void Awake()
    {
        baseHero = GetComponent<BaseHero>();
    }

    public void SetUp(bool isPlayerTeam)
    {
        //baseHero.GetMaterial().
    }
}
