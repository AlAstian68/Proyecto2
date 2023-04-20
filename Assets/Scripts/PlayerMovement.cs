using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private Rigidbody2D rigid;
    private float h;
    public float vel;
    public float jumpSpeed = 30;
    private Animator anim;
    //for shoting
    bool lado = false;
    bool jump = false;
    
    public bool betterJummp = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    //en-tierra
    const float player_size = 0.2f;
    public LayerMask esto_tierra;
    public Transform tierra_verificada;

    //for shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
  
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jump = false;
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        if(h < 0 && !lado){
            lado = !lado;
            transform.Rotate(0f,180f,0f);
        }else if (h > 0 && lado){
            lado = !lado;
            transform.Rotate(0f,180f,0f);
        }
        
        anim.SetFloat("Player1Run",h);
        rigid.MovePosition(rigid.position + new Vector2(h,0) * vel * Time.deltaTime);

        esta_en_tierra();
        if(Input.GetButton("Jump") && !jump){
            jump = true;
            rigid.AddForce(new Vector2(0f, jumpSpeed));

        }
        /*
        if (betterJummp)
        {
            if (rigid.velocity.y < 0)
            {
                rigid.velocity += Vector2.up*Physics2D.gravity.y*(fallMultiplier)*Time.deltaTime;
            }
            if (rigid.velocity.y > 0 && !Input.GetKey("space"))
            {
                rigid.velocity += Vector2.up*Physics2D.gravity.y*(lowJumpMultiplier)*Time.deltaTime;
            }
        }
*/
        if(Input.GetButtonDown("Fire1")){
            shoot();
            //StartCoroutine(stop_anim());
        }
    }

    void shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    IEnumerator stop_anim(){
        Debug.Log("estamos en la coroutine");
        yield return new WaitForSeconds(.8f);
        //anim.SetBool("disparando",false);
    }

    void esta_en_tierra(){

        Collider2D[] colliders = Physics2D.OverlapCircleAll(tierra_verificada.position, player_size,esto_tierra);
        for(int i = 0; i < colliders.Length; i++){
            if(colliders[i].gameObject != gameObject){
                jump = false;
                //anim.SetBool("EstaSaltando",false);
            }
        }
        
    }

/*
     void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "enemy"){
            Debug.Log("Entro en el colider");
            //vida = vida - 20;
        }
    }
*/
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "abyss"){
            Debug.Log("Perdiste");
            //Activar popups
            //popups.enabled = true;
            Debug.Log("Popup active");
            Time.timeScale = 0f;
        }
    }
        /*if(other.gameObject.tag == "flag"){
            Debug.Log("Ganaste!");
            //popups.enabled = true;
            Time.timeScale = 0f;
        }
    }*/
}
