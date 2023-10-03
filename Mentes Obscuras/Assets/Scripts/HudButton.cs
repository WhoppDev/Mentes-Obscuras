using UnityEngine;
using UnityEngine.SceneManagement;

public class HudButton : MonoBehaviour
{
    public void CircuTeleport()
    {
        SceneManager.LoadScene("Circo");
    }

    public void FlorestTeleport()
    {
        SceneManager.LoadScene("Floresta");
    }
}
