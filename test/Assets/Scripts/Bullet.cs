using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 5;

  
    void Start()
    {
        Destroy(gameObject, life);
    }

   

}
