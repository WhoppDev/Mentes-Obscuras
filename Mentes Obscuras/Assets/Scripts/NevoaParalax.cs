using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevoaParalax : MonoBehaviour
{
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
