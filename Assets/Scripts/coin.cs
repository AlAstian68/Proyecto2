using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
   void OnTriggerEnter2D (Collider2D collider){
        score.puntaje++;
        enemy_life.life--;
        guardar.modificaXml("player One", score.puntaje.ToString());
        Destroy(gameObject);
    }

}
