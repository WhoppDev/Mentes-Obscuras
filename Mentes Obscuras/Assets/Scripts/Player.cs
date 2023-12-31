using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public bool isJumping;
    public bool doubleJump;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;

        }

        

        if(collision.gameObject.tag == "faca")
        {
            Core.Instance.gameManager.ShowGameOver();
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = true;

        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Spikes")
        {
            Core.Instance.gameManager.ShowGameOver();
        
        }  
        if(collision.gameObject.tag == "DeathZone")
        {
            Core.Instance.gameManager.ShowGameOver();
        
        }  
    }


}

