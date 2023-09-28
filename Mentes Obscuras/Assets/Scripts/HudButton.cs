using UnityEngine;
using UnityEngine.SceneManagement;

public class HudButton : MonoBehaviour
{
    public void CircuTeleport()
    {
        SceneManager.LoadScene("Circo1");
    }

    public void FlorestTeleport()
    {
        SceneManager.LoadScene("Floresta");
    }
}
