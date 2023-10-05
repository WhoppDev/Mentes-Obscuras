using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOver;

    public static GameManager instance;
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
        Time.timeScale = 0f;

    }
    public void RestartGame(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1f;

    }
}
