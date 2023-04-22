using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 40;
    public Rigidbody2D rb;
    //public GameObject impacEffct;
    private GameObject enemigo;
    void Start(){
        rb.velocity = transform.right * speed;    
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "enemy"){

            //Quitarle vida o destruirlo
            string obj = col.gameObject.name;
            enemigo = GameObject.Find(obj);
            Enemy1 script = enemigo.GetComponent<Enemy1>();
            //script.TomarDanio(damage);
            Destroy(gameObject);
        }else{
            //Crear prefab de animacion de impacto
            //Instantiate(impacEffct, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Update(){
        Destroy (gameObject, 5.0f);
    }
}
