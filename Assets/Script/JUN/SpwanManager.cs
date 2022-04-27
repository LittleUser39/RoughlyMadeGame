using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
   public GameObject obj;
    float randomX; //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
    float randomY; 
        private void Start() {
            Spwan();
        }
        void Spwan()
        {
             randomX = Random.Range(8f, 14f); 
            randomY = Random.Range(26f, 30f); 
            GameObject encounter = (GameObject)Instantiate(obj, new Vector3(randomX, randomY, 0f), Quaternion.identity);  
            randomX = Random.Range(8f, 14f); 
            randomY = Random.Range(26f, 30f); 
            GameObject encounter1 = (GameObject)Instantiate(obj, new Vector3(randomX, randomY, 0f), Quaternion.identity);  
           randomX = Random.Range(8f, 14f); 
            randomY = Random.Range(26f, 30f); 
            GameObject encounter2 = (GameObject)Instantiate(obj, new Vector3(randomX, randomY, 0f), Quaternion.identity);  
            randomX = Random.Range(8f, 14f); 
            randomY = Random.Range(26f, 30f); 
            GameObject encounter3 = (GameObject)Instantiate(obj, new Vector3(randomX, randomY, 0f), Quaternion.identity); 
            this.enabled = false;
        }


}
