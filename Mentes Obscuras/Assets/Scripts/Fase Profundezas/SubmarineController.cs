using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem ;

public class SubmarineController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem particle;

    [SerializeField] private float submarineSpeed;

    [SerializeField] Vector2 direction;

    public bool turnOn;

    [SerializeField] private GameObject playerPrefab;    
    [SerializeField] private GameObject submarineCam;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (turnOn)
        {
            rb.velocity = new Vector2(direction.x * submarineSpeed, direction.y * submarineSpeed);


            if (direction.x < 0)
            {
                transform.localScale = new Vector2(-1f, 1f);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector2(1f, 1f);
            }
        }

    }

    public void SubmarineMoviment(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particle.Play();
            anim.SetBool("turnOn", true);
            Destroy(playerPrefab);
            submarineCam.SetActive(true);
            turnOn = true;
        }

    }

}
