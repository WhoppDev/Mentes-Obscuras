using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public float levelDuration = 125f; 

    private float elapsedTime = 0f;
    private bool levelEnded = false;

    void Update()
    {
        if (!levelEnded)
        {
            elapsedTime += Time.deltaTime;

           
            if (elapsedTime >= levelDuration)
            {
                EndLevel();
            }
        }
    }

    void EndLevel()
    {
        
        levelEnded = true;

        
        SceneManager.LoadScene("INICIAL"); 
    }
}
