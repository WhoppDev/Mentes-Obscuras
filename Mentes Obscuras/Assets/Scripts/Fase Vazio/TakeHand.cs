using UnityEngine;

public class TakeHand : MonoBehaviour
{
    [SerializeField] private Collider2D tryTakeCollider;
    [SerializeField] private Collider2D takeCollider;
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tryTakeCollider.IsTouching(collision))
        {
            anim.SetBool("IsNear", true);
        }

        if (takeCollider.IsTouching(collision))
        {
            anim.SetBool("IsNear", true);
            anim.SetTrigger("IsTake");
            Core.Instance.gameManager.ShowGameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            anim.SetBool("IsNear", false);
    }
}
