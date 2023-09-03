using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

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
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction.x * playerSpeed, rb.velocity.y);

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }


    public void Moviment(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    public void Jump (InputAction.CallbackContext value)
    {
        if (value.started)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

}
