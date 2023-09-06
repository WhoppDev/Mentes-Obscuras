using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public static Core Instance;

    public GameManager gameManager;

    private void Awake()
    {

        DontDestroyOnLoad(this);
        if (Instance != null && Instance !=this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
