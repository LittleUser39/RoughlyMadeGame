using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBattle : MonoBehaviour
{
    public bool isTurn;
    public float moveSpeed = 5f;
    Vector2 prevPos;
    Vector2 dir;
    bool isMoving=false;
    private void FixedUpdate()
    {
        if(isMoving)
        {
            
            transform.Translate(dir*moveSpeed*Time.deltaTime);
        }
    }
    public void Approach(Vector2 _dir)
    {
        prevPos = transform.position;
        dir = _dir;
        isMoving=true;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag=="Player"||other.gameObject.tag=="Companion") && isTurn)
        {
            dir = (prevPos - (Vector2)transform.position).normalized;
            StartCoroutine(StopMoving());
        }
    }
    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(0.2f);
        isMoving = false;
        transform.position = prevPos;
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().isBattlePaused = false;
        isTurn=false;
    }
}
