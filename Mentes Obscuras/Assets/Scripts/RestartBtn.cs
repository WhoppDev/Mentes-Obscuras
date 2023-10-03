using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    [SerializeField] private GameObject restartPanel;

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
        restartPanel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("INICIAL");
        restartPanel.SetActive(false);
    }
}
