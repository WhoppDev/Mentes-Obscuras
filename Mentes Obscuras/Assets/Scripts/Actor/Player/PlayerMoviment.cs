using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Animator anim;
    private bool isUpperLantern = false;
    [SerializeField] GameObject frontLantern;
    [SerializeField] GameObject upperLantern;

    [SerializeField] private bool isGrounded = false;
    public bool isSwiming = false;

    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        frontLantern.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * playerSpeed, rb.velocity.y);


        if (direction.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }



        #region LanternMoviment
        if (direction.magnitude > 0.01f && !isUpperLantern && isGrounded)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }



        if (direction.magnitude > 0.01f && isUpperLantern && isGrounded)
        {
            anim.SetBool("isUpper", true);
        }
        else if (direction.magnitude <= 0 && isUpperLantern && isGrounded)
        {
            anim.SetBool("isUpperStop", true);
        }
        else
        {
            anim.SetBool("isUpper", false);
            anim.SetBool("isUpperStop", false);
        }
        #endregion
    }


    public void Moviment(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }

    public void Jump (InputAction.CallbackContext value)
    {
        if (value.started && isGrounded && !isSwiming)
        {
            anim.SetBool("Jump", true);
            rb.velocity = Vector2.up * jumpForce ;
            isGrounded = false;
        }
        else if (value.started && isSwiming)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void UpperLanten(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            frontLantern.SetActive(false);
            upperLantern.SetActive(true);
            isUpperLantern = true;
        }
        if (value.canceled)
        {
            frontLantern.SetActive(true);
            upperLantern.SetActive(false);
            isUpperLantern = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
            anim.SetBool("isFalling", false);

        }
    }

}
