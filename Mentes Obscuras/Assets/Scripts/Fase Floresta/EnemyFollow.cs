using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject target;
    public float enemySpeed;
    public Rigidbody2D rb;

    [SerializeField] private float enemyLife;

    [SerializeField] private Collider2D lanternCollider;

    [SerializeField] private float lanternDamage = 10f;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private bool isRepelled = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("NPC");
        lanternCollider = GameObject.FindWithTag("Lantern").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;

        if (isRepelled)
        {
            rb.velocity = -direction * enemySpeed; // Inverso da direção do alvo
        }
        else
        {
            rb.velocity = new Vector2(direction.x * enemySpeed, rb.velocity.y);
        }

        if (direction.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == lanternCollider)
        {
            isRepelled = true;

            // Reduzir a vida do inimigo
            enemyLife -= lanternDamage * Time.deltaTime; // Ajustado para que o dano seja contínuo

            if (enemyLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == lanternCollider)
        {
            isRepelled = false;
        }
    }



}
