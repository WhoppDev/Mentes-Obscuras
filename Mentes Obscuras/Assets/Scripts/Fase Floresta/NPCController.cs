using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public Transform[] target;
    public float npcSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    [SerializeField] private Image afraidBar;

    [SerializeField] private int targetAtivo = 0;
    public bool isAfraid;
    public float afraidDecreaseRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target[targetAtivo].position, transform.position) <= 1f)
        {
            targetAtivo = (targetAtivo + 1) % target.Length;
        }

        if (isAfraid)
        {
            anim.SetBool("isAfraid", true);
            DecreaseAfraidBar();
        }
        else
        {
            anim.SetBool("isAfraid", false);
        }
    }

    void FixedUpdate()
    {
            Vector2 direction = (target[targetAtivo].position - transform.position).normalized;

            if (direction.x < 0)
            {
                transform.localScale = new Vector2(-1f, 1f);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector2(1f, 1f);
            }

        if (!isAfraid)
        {
            rb.velocity = new Vector2(direction.x * npcSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(direction.x * 0, rb.velocity.y);
        }
    }

    void DecreaseAfraidBar()
    {
        if (afraidBar.fillAmount > 0)
        {
            afraidBar.fillAmount -= afraidDecreaseRate * Time.deltaTime;
        }
        else
        {
            Core.Instance.gameManager.ShowGameOver();
            isAfraid = false;
        }
    }

}
