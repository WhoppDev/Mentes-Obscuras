using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform[] target;
    public float npcSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.2f;
    public Collider2D enemyDetect;

    [SerializeField] private int targetAtivo = 0;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Vector2.Distance(target[targetAtivo].position, transform.position) < 1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            targetAtivo = (targetAtivo + 1) % target.Length;
        }
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            Vector2 direction = (target[targetAtivo].position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * npcSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == enemyDetect && collision.gameObject.CompareTag("Enemy")) ;
        {
            rb.velocity = transform.position;
        }
    }




}
