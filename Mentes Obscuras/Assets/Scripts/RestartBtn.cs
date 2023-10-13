using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private AudioSource deathAudio;

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
        restartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("INICIAL");
        restartPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
