using UnityEngine;

public class MovimentoObjeto : MonoBehaviour
{
    public Transform targetPosition; // Ponto de destino
    public float velocidadeMovimento = 5f; // Velocidade de movimento

    private void Update()
    {
        // Calcula a direção do movimento do objeto
        Vector3 direction = (targetPosition.position - transform.position).normalized;

        // Calcula a distância entre o objeto e o ponto de destino
        float distance = Vector3.Distance(transform.position, targetPosition.position);

        // Verifica se o objeto chegou ao ponto de destino
        if (distance > 0.01f)
        {
            // Move o objeto na direção do ponto de destino com a velocidade especificada
            transform.position += direction * velocidadeMovimento * Time.deltaTime;
        }
    }
}
