using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;

    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * playerSpeed, rb.velocity.y);
    }


    public void Moviment(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }

    public void Jump (InputAction.CallbackContext value)
    {
        if (value.started)
        {
            rb.velocity = Vector2.up * jumpForce ;
        }
    }

}
