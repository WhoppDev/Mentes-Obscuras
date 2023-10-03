using System.Collections;
using UnityEngine;

public class BossProjeteis : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab a ser lançado
    public Transform player; // Referência ao objeto "player"
    public float launchInterval = 2f; // Intervalo entre os lançamentos
    public float launchSpeed = 10f; // Velocidade do lançamento

    private float timeSinceLastLaunch = 0f;

    void Update()
    {
        // Controle do intervalo de lançamento
        timeSinceLastLaunch += Time.deltaTime;
        if (timeSinceLastLaunch >= launchInterval)
        {
            LaunchProjectile();
            timeSinceLastLaunch = 0f;
        }

        // Rotacione o SpawnPoint para mirar na direção do player
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
            // Cria o projétil
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Obtém o Rigidbody2D do projétil
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Define a velocidade do projétil
            rb.velocity = transform.right * launchSpeed; // Usamos transform.right para a direção "frente" do SpawnPoint
        }
    }
}
