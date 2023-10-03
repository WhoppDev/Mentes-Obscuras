using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    public GameObject[] attackPrefabs; // Array de prefabs de ataques (3 diferentes)
    public Transform player; // Referência ao jogador

    public float attackCooldown = 2f; // Tempo de recarga entre os ataques
    private float currentCooldown = 0f;

    void Update()
    {
        // Controle do tempo de recarga entre os ataques
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            // Escolhe aleatoriamente um dos ataques
            int randomAttackIndex = Random.Range(0, attackPrefabs.Length);

            // Cria e dispara o ataque escolhido
            GameObject attack = Instantiate(attackPrefabs[randomAttackIndex], transform.position, Quaternion.identity);

            // Ajuste a direção do ataque, se necessário
            BossAttackScript attackScript = attack.GetComponent<BossAttackScript>();
            if (attackScript != null)
            {
                attackScript.SetTarget(player);
            }

            // Reinicia o tempo de recarga
            currentCooldown = attackCooldown;
        }
    }
}
