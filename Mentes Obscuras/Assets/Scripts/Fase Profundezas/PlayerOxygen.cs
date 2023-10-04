using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOxygen : MonoBehaviour
{
    [SerializeField] private Image oxygenBar;

    public bool haveOxygen;
    public float afraidDecreaseRate = 0.1f;

    public GameObject bubblePrefab; // Arraste o prefab da bolha aqui
    public Transform[] spawnPoints; // Arraste os pontos de spawn aqui
    public float spawnRate = 2f; // Quantas vezes por segundo você quer spawnar uma bolha
    public float bubbleRiseSpeed = 2f; // Velocidade das bolhas subindo

    [SerializeField] private SubmarineController submarine;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBubbles());
    }

    // Update is called once per frame
    void Update()
    {
        if (!haveOxygen && !submarine.turnOn)
        {
            DecreaseOxygenBar();
        }

    }

    void DecreaseOxygenBar()
    {
        if (oxygenBar.fillAmount > 0)
        {
            oxygenBar.fillAmount -= afraidDecreaseRate * Time.deltaTime;
        }
        else
        {
            Core.Instance.gameManager.ShowGameOver();
        }
    }

    private IEnumerator SpawnBubbles()
    {
        while (true)
        {
            // Escolha um ponto de spawn aleatório
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Crie a bolha no ponto de spawn
            GameObject bubble = Instantiate(bubblePrefab, spawnPoint.position, Quaternion.identity);

            // Inicia a lógica de movimento da bolha (fazendo ela subir)
            StartCoroutine(MoveBubble(bubble.transform));

            // Espera pelo tempo de spawn definido antes de gerar a próxima bolha
            yield return new WaitForSeconds(1f / spawnRate);
        }
    }

    private IEnumerator MoveBubble(Transform bubbleTransform)
    {
        while (true)
        {
            bubbleTransform.position += Vector3.up * bubbleRiseSpeed * Time.deltaTime;
            yield return null;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            oxygenBar.fillAmount = 1;
        }
    }
}
