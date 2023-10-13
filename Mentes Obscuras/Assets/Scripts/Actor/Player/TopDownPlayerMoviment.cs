using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movement * speed;

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", speed);

        if (movement.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void Move(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
    }

}
