using System.Collections;
using UnityEngine;

public class PeixeLuzController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector2 direction;

    private bool isFollowingTarget = false;
    private float randomMoveDuration = 2f; // Duração do movimento aleatório
    private float randomPauseDuration = 1f; // Duração da pausa entre movimentos aleatórios
    private bool isMovingRandomly = false;


    void Start()
    {
        StartCoroutine(RandomMovement());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFollowingTarget && target != null)
        {
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isFollowingTarget = true;
            target = collision.gameObject;
            direction = (target.transform.position - transform.position).normalized;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isMovingRandomly)
        {
            isFollowingTarget = false;
            target = null;
            rb.velocity = Vector2.zero;
            StartCoroutine(RandomMovement());
        }
    }

    private IEnumerator RandomMovement()
    {
        isMovingRandomly = true;
        while (!isFollowingTarget)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            direction = new Vector2(randomX, randomY).normalized; // Defina 'direction' aqui
            rb.velocity = direction * speed;
            yield return new WaitForSeconds(randomMoveDuration);
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(randomPauseDuration);
        }
        isMovingRandomly = false;
    }
    
}
