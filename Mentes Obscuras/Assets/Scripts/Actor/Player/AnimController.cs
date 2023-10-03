using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string sceneName;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Circo":
                anim.SetBool("isLantern", false);
                break;

            case "Floresta":
                anim.SetBool("isLantern", true);
                break;

            case "Profundezas":

                break;
        }
    }
}
