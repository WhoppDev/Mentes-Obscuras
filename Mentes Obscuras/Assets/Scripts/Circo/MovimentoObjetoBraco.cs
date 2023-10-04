using UnityEngine;

public class MovimentoObjetoBraco : MonoBehaviour
{
    public Transform targetPosition;
    public float velocidadeMovimento = 5f;
    public float delayTime = 2f;
    public float returnDelayTime = 2f;
    public int maxCycles = 3; // Número máximo de ciclos permitidos

    private float delayTimer = 0f;
    private float returnDelayTimer = 0f;
    private bool canMove = false;
    private bool isReturning = false;
    private int cycleCount = 0; // Contador de ciclos

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (cycleCount < maxCycles) // Verifica se o número de ciclos ainda não atingiu o limite
        {
            if (!canMove)
            {
                delayTimer += Time.deltaTime;

                if (delayTimer >= delayTime)
                {
                    canMove = true;
                    delayTimer = 0f;
                }
            }

            if (canMove && !isReturning)
            {
                Vector3 direction = (targetPosition.position - transform.position).normalized;
                float distance = Vector3.Distance(transform.position, targetPosition.position);

                if (distance > 0.01f)
                {
                    transform.position += direction * velocidadeMovimento * Time.deltaTime;
                }
                else
                {
                    returnDelayTimer += Time.deltaTime;

                    if (returnDelayTimer >= returnDelayTime)
                    {
                        isReturning = true;
                        returnDelayTimer = 0f;
                    }
                }
            }

            if (isReturning)
            {
                Vector3 returnDirection = (initialPosition - transform.position).normalized;
                float returnDistance = Vector3.Distance(transform.position, initialPosition);

                if (returnDistance > 0.01f)
                {
                    transform.position += returnDirection * velocidadeMovimento * Time.deltaTime;
                }
                else
                {
                    isReturning = false;
                    cycleCount++; // Incrementa o contador de ciclos quando um ciclo completo é concluído
                }
            }
        }
    }
}
