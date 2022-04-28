using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBattle : MonoBehaviour
{   
    public GameObject explosive;
    Vector2 beamDir;
    uint explosionCounter = 0;
    public bool isTurn;
    public float moveSpeed = 1f;
    Vector2 prevPos;
    Vector2 dir;
    bool isMoving=false;
    bool isSkill=false;
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
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().isBattlePaused = false;
        isTurn=false;
    }

    public void UseSkill(Vector2 dir)
    {
        beamDir = dir;
        isSkill=true;
        StartCoroutine(SkillExplode());
    }
    public void Explosion()
    {
        ++explosionCounter;
        Instantiate(explosive,new Vector2(transform.position.x+beamDir.x*explosionCounter,transform.position.y+beamDir.y*explosionCounter),Quaternion.identity);
        Invoke("Explosion",0.2f); 
        if(explosionCounter >=10)
        {
            CancelInvoke();
            explosionCounter = 0;
            isSkill=false;   
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>().isBattlePaused = false;   
        }   
    }
    IEnumerator SkillExplode()
    {
        yield return new WaitForSeconds(0.2f);
        Invoke("Explosion",0.2f); 
        
    }
}
