using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    private float direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * playerSpeed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    public void Moviment(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    public void Jump (InputAction.CallbackContext value)
    {
        if (value.started)
        {
            rb.AddForce(Vector2.up * jumpForce );
        }
    }

}
