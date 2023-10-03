using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjeteis : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;

    public void ShootAtPlayer()
    {
        if (player != null && projectilePrefab != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }
}
