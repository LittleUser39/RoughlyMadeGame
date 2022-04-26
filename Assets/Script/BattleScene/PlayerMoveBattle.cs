using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBattle : MonoBehaviour
{   
    public bool isTurn;
    public float moveSpeed = 1f;
    Vector2 prevPos;
    Vector2 dir;
    bool isMoving=false;
    private void FixedUpdate()
    {
        if(isMoving)
        {
            Debug.Log(dir);
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
        if(other.gameObject.tag=="Monster" && isTurn)
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
        BattleManager.instance.isBattlePaused = false;
        isTurn=false;
        StopCoroutine(StopMoving());
    }
}
