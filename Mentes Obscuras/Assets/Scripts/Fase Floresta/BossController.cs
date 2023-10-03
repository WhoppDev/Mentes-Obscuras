using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float bossSpeed;
    [SerializeField] private Rigidbody2D rb;


    private void Update()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;

        rb.velocity = new Vector2(rb.velocity.x, direction.y * bossSpeed);

    }
}
