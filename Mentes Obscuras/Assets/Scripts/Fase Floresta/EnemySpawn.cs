using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoint;
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    private IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); 

            // Spawn enemy at a random spawn point
            GameObject chosenSpawnPoint = spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)];
            Instantiate(enemyPrefab, chosenSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
