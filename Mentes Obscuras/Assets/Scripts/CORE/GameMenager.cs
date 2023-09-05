using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{

    public GameObject gameOver;

    public static GameMenager instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Circo1");

    }
}
