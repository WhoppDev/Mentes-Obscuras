using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string sceneName;
    [SerializeField] private PlayerMoviment moviment;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        moviment = FindAnyObjectByType<PlayerMoviment>();

        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Circo":
                anim.SetBool("isLantern", false);
                moviment.isSwiming = false;
                break;

            case "Floresta":
                anim.SetBool("isLantern", true);
                moviment.isSwiming = false;
                break;

            case "Profundezas":
                anim.SetBool("isLantern", false);
                anim.SetBool("isSwiming", true);
                moviment.isSwiming = true;
                break;
        }
    }
}
