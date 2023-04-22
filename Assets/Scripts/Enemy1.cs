using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public static int enemylive = 100;
    private Animator anim;
    public GameObject impacEffct;
    void Start(){
        anim = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.name == "player"){
            anim.SetBool("saltar", true);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.name == "player"){
            anim.SetBool("saltar",false);
        }
    }

    public void TomarDanio(int danio){
        enemylive = enemylive - danio;
        Debug.Log(gameObject.name);
    }

    void Update(){
        if(enemylive < 1 ){
            Instantiate(impacEffct, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
