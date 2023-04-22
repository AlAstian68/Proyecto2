using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private Rigidbody2D rb2D;
    private float h;
    //public float vel;
    //public float jumpSpeed = 30;
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    private Animator anim;
    //for shoting
    bool lado = false;
    //bool jump = false;
    
    public bool betterJummp = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    //public SpriteRenderer spriteRenderer;

    //en-tierra
    const float player_size = 0.2f;
    public LayerMask esto_tierra;
    public Transform tierra_verificada;

    //for shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
  
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
     
    }

    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            //spriteRenderer.flipX = false;
          
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            //spriteRenderer.flipX = true;
           
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        //Working fli pmovement
        h = Input.GetAxis("Horizontal");
        if(h < 0 && !lado){
            lado = !lado;
            transform.Rotate(0f,180f,0f);
        }else if (h > 0 && lado){
            lado = !lado;
            transform.Rotate(0f,180f,0f);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if(betterJummp)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if(rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }

        }
        
        anim.SetFloat("Player1Run",h);
        //rb2D.MovePosition(rb2D.position + new Vector2(h,0) * runSpeed * Time.deltaTime);

        /*esta_en_tierra();
        if(Input.GetButton("Jump") && !jump){
            jump = true;
            rb2D.AddForce(new Vector2(0f, jumpSpeed));
        
        }*/
        /*
        
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

    /*void esta_en_tierra(){

        Collider2D[] colliders = Physics2D.OverlapCircleAll(tierra_verificada.position, player_size,esto_tierra);
        for(int i = 0; i < colliders.Length; i++){
            if(colliders[i].gameObject != gameObject){
                jump = false;
                //anim.SetBool("EstaSaltando",false);
            }
        }
        
    }
*/
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
