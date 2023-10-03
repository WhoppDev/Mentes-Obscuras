using System.Collections;
using UnityEngine;

public class BossProjeteis : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform player; 
    public float launchInterval = 2f; 
    public float launchSpeed = 10f; 

    private float timeSinceLastLaunch = 0f;

    void Update()
    {
        
        timeSinceLastLaunch += Time.deltaTime;
        if (timeSinceLastLaunch >= launchInterval)
        {
            LaunchProjectile();
            timeSinceLastLaunch = 0f;
        }

        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void LaunchProjectile()
    {
        if (projectilePrefab != null)
        {
           
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

           
            rb.velocity = transform.right * launchSpeed; 
        }
    }
}
