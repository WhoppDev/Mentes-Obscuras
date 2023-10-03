using Cinemachine;
using UnityEngine;

public class ScreenShakeCamera : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] float powerAmount = 1f;

    private bool isShaking = false;

    public void ScreenShake(Vector3 dir)
    {
        if (screenShake != null)
        {
            screenShake.GenerateImpulseWithVelocity(dir);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isShaking && collision.gameObject.CompareTag("Player"))
        {
            isShaking = true;
            Vector3 shake = new Vector3(1, 2, 1) * powerAmount;
            Debug.Log("Generating Screen Shake with " + shake.ToString());
            ScreenShake(shake);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isShaking && collision.gameObject.CompareTag("Player"))
        {
            isShaking = false;
            // Aqui você pode parar ou diminuir o shake, se necessário
            // Por exemplo, resetando a intensidade ou usando algum outro mecanismo.
        }
    }
}
