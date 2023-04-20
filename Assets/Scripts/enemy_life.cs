using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_life : MonoBehaviour
{
    public static int life;

    void Start()
    {
        life = 4;
    }

    void Update()
    {
        if (life == 0){
            Destroy(gameObject);
        }
    }
}
