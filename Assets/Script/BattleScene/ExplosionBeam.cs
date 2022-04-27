using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBeam : MonoBehaviour
{
    public float moveSpeed  = 5f;
    private void Awake()
    {
        Destroy(gameObject,1);
    }

}
